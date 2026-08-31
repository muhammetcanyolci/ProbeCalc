using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{ /// <summary>Manyetik kuvvetin hangi fiziksel senaryodan kaynaklandığı.</summary>
	public enum MagneticForceMode
	{
		MovingCharge,        // Hareketli Yük: F = q * v * B * sin(θ)
		CurrentCarryingWire  // Akım Taşıyan Tel: F = B * I * L * sin(θ)
	}
/// <summary>
	 /// Manyetik Kuvvet hesaplamalarını yapan somut motor sınıfı. PhysicsEngine'den
	 /// doğrudan miras alır (elektrostatik Distance/CoulombConstant'a ihtiyacı yok).
	 ///
	 /// MİMARİ KARAR: İki mod da yapısal olarak aynı formül ailesi —
	 /// F = (çarpan) * (birincil büyüklük) * B * sin(θ). "Çarpan" Mod 1'de yük
	 /// (q), Mod 2'de tel uzunluğu (L); "birincil büyüklük" Mod 1'de hız (v),
	 /// Mod 2'de akım (I). Bu yüzden TEK bir hesaplama yolu var.
	 ///
	 /// FONKSİYON DESTEĞİ (ImpulseMomentumEngine ile AYNI DESEN): Hem manyetik
	 /// alan (B) hem birincil büyüklük (v ya da I), sabit bir değer OLABİLECEĞİ
	 /// GİBİ, zamana bağlı bir Func&lt;double,double&gt; delegesi de OLABİLİR.
	 /// Fonksiyon verilmemişse (null), sabit değere düşülür — MathParser'dan
	 /// gelen delegeler doğrudan buraya, motorun içine hiç MathParser/regex
	 /// bağımlılığı sızdırmadan enjekte edilir (ImpulseMomentumEngine'deki
	 /// "MathParser içeri gömülmedi, dışarıdan delege alınıyor" kuralı).
	 /// </summary>
		public class MagneticForceEngine : PhysicsEngine
			{
			// 1. GİRDİLER (INPUTS)

			public MagneticForceMode Mode { get; set; } = MagneticForceMode.MovingCharge;

			// v/I ile B arasındaki açı (derece). Çoğu problemde dik (90°) olduğu
			// için varsayılan 90 — kullanıcı çoğu zaman bu alana hiç dokunmaz.
			private double _angleDegrees = 90;
			public double AngleDegrees
			{
				get => _angleDegrees;
				set
				{
					if (value < 0 || value > 180)
						throw new ArgumentOutOfRangeException(nameof(AngleDegrees), "Açı (θ) 0 ile 180 derece arasında olmalıdır.");
					_angleDegrees = value;
				}
			}

			// Manyetik alan (B) - Tesla. Sabit değer; fonksiyon verilirse onun yerine kullanılır.
			public double MagneticField { get; set; }
			public Func<double, double> MagneticFieldFunction { get; set; }

			// --- Mod 1: Hareketli Yük ---
			private double _charge;
			public double Charge
			{
				get => _charge;
				set
				{
					if (value == 0)
						throw new ArgumentOutOfRangeException(nameof(Charge), "Yük (q) sıfır olamaz.");
					_charge = value;
				}
			}
			public double Velocity { get; set; }
			public Func<double, double> VelocityFunction { get; set; }

			// --- Mod 2: Akım Taşıyan Tel ---
			public double Current { get; set; }
			public Func<double, double> CurrentFunction { get; set; }

			private double _wireLength;
			public double WireLength
			{
				get => _wireLength;
				set
				{
					if (value <= 0)
						throw new ArgumentOutOfRangeException(nameof(WireLength), "Tel uzunluğu (L) sıfırdan büyük olmalıdır.");
					_wireLength = value;
				}
			}

			// Sadece B veya birincil büyüklük FONKSİYON olarak verildiyse gereklidir
			// (sayısal integrasyon aralığı). Sabit-değer modunda kullanılmaz.
			public double DeltaTime { get; set; }
			public double StepSize { get; set; } = 0.001;

			// 2. ÇIKTILAR (OUTPUTS)
			public double Force { get; private set; }        // Sabit modda ANLIK, fonksiyon modunda ORTALAMA kuvvet
			public double TotalImpulse { get; private set; } // Sadece fonksiyon modunda anlamlı (J = ∫F dt)
			public bool IsFunctionMode { get; private set; }

			// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ (sadece fonksiyon modunda dolar)
			public double[] ChartX_Time { get; private set; }
			public double[] ChartY_Force { get; private set; }

			// 4. HESAPLAMA MANTIĞI (CALCULATE)
			public override void Calculate()
			{
				double thetaRad = DegreesToRadian(AngleDegrees);
				double sinTheta = Math.Sin(thetaRad);

				Func<double, double> primaryFunction = Mode == MagneticForceMode.MovingCharge ? VelocityFunction : CurrentFunction;
				double primaryConstant = Mode == MagneticForceMode.MovingCharge ? Velocity : Current;
				double multiplier = Mode == MagneticForceMode.MovingCharge ? Charge : WireLength;
				string primaryLabel = Mode == MagneticForceMode.MovingCharge ? "v (Hız)" : "I (Akım)";
				string multiplierLabel = Mode == MagneticForceMode.MovingCharge ? "q (Yük)" : "L (Tel Uzunluğu)";
				string formulaText = Mode == MagneticForceMode.MovingCharge ? "F = q * v * B * sin(θ)" : "F = B * I * L * sin(θ)";

				IsFunctionMode = primaryFunction != null || MagneticFieldFunction != null;

				SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI (MANYETİK KUVVET) ---\n\n";
				SolutionSteps += $"Kullanılan Formül: {formulaText}\n";
				SolutionSteps += $"Çarpan ({multiplierLabel}) = {multiplier:F4}\n";
				SolutionSteps += $"Açı (θ) = {AngleDegrees}°  ->  sin(θ) = {sinTheta:F4}\n\n";

				if (!IsFunctionMode)
				{
					// --- SABİT DEĞER MODU: tek formül, integrasyon yok ---
					Force = multiplier * primaryConstant * MagneticField * sinTheta;
					TotalImpulse = 0;
					ChartX_Time = null;
					ChartY_Force = null;

					SolutionSteps += "Mod: Sabit Değerler (anlık kuvvet)\n";
					SolutionSteps += $"İşlem: {multiplier:F4} * {primaryConstant:F4} ({primaryLabel}) * {MagneticField:F4} (B) * {sinTheta:F4} = {Force:E4} N\n";
				}
				else
				{
					// --- FONKSİYON MODU: sayısal integrasyon (ImpulseMomentumEngine deseni) ---
					if (DeltaTime <= 0)
						throw new ArgumentOutOfRangeException(nameof(DeltaTime), "Fonksiyon modunda geçen süre (Δt) sıfırdan büyük olmalıdır.");
					if (StepSize <= 0)
						throw new ArgumentOutOfRangeException(nameof(StepSize), "Adım boyutu (StepSize) sıfırdan büyük olmalıdır.");

					var timeList = new List<double>();
					var forceList = new List<double>();
					double impulse = 0;

					for (double t = 0; t <= DeltaTime; t += StepSize)
					{
						double bAtT = MagneticFieldFunction != null ? MagneticFieldFunction(t) : MagneticField;
						double primaryAtT = primaryFunction != null ? primaryFunction(t) : primaryConstant;
						double forceAtT = multiplier * primaryAtT * bAtT * sinTheta;

						timeList.Add(t);
						forceList.Add(forceAtT);
						impulse += forceAtT * StepSize;
					}

					TotalImpulse = impulse;
					Force = impulse / DeltaTime; // Ortalama kuvvet

					ChartX_Time = timeList.ToArray();
					ChartY_Force = forceList.ToArray();

					SolutionSteps += "Mod: Zamana Bağlı Fonksiyon (sayısal integrasyon)\n";
					SolutionSteps += $"B(t) : {(MagneticFieldFunction != null ? "fonksiyon olarak verildi" : $"sabit {MagneticField:F4} T")}\n";
					SolutionSteps += $"{primaryLabel}(t) : {(primaryFunction != null ? "fonksiyon olarak verildi" : $"sabit {primaryConstant:F4}")}\n";
					SolutionSteps += $"Toplam İtme (J = ∫F dt) : {TotalImpulse:E4} N.s\n";
					SolutionSteps += $"Ortalama Kuvvet (J/Δt) : {Force:E4} N\n";
				}

				SolutionSteps += "\n--------------------------------------------------\n";
				SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
				SolutionSteps += $"   Kuvvet {(IsFunctionMode ? "(Ortalama)" : "(Anlık)")} : {Force:E4} N\n";
				if (IsFunctionMode)
					SolutionSteps += $"   Toplam İtme (J)         : {TotalImpulse:E4} N.s\n";
			}

			protected override string GetShortResultText()
			{
				return IsFunctionMode
					? $" Ortalama Kuvvet : {Force:E4} N\n Toplam İtme (J) : {TotalImpulse:E4} N.s\n"
					: $" Kuvvet (F)      : {Force:E4} N\n";
			}

			public override void Reset()
			{
				Mode = MagneticForceMode.MovingCharge;
				_angleDegrees = 90;
				MagneticField = 0;
				MagneticFieldFunction = null;

				_charge = 0;
				Velocity = 0;
				VelocityFunction = null;

				Current = 0;
				CurrentFunction = null;
				_wireLength = 0;

				DeltaTime = 0;
				StepSize = 0.001;

				Force = 0;
				TotalImpulse = 0;
				IsFunctionMode = false;

				ChartX_Time = null;
				ChartY_Force = null;

				SolutionSteps = string.Empty;
			}
		}
	
}
