using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	/// <summary>İndüktans hesaplamasının hangi senaryoya ait olduğu.</summary>
	public enum InductanceMode
	{
		SelfInductance,   // Öz İndüktans (tek bobin)
		MutualInductance  // Karşılıklı İndüktans (iki bobin, ortak çekirdek)
	}
	/// <summary>
	 /// İndüktans (Inductance) hesaplamalarını yapan somut motor sınıfı.
	 /// PhysicsConstants.VacuumPermeability doğrudan çağrılır (ayrı bir ata sınıf gerekmedi).
	 ///
	 /// Bilerek FaradayEngine'den AYRI bir motor — konuşmamızda "indüktansı
	 /// ayrı bir konu olarak ele alacağız" demiştik. Faraday Yasası'ndaki
	 /// "sabit halka - değişen alan" senaryosuyla aynı matematiksel iskeleti
	 /// (ε = -X * (ΔI/Δt) biçiminde) paylaşsa da, kavramsal olarak farklı bir
	 /// olgu: burada devrenin KENDİ akımındaki değişim kendi (ya da komşu bir
	 /// bobinin) EMK'sını indükliyor — dışarıdan bir B alanı değişimi yok.
	 /// </summary>
	public class InductanceEngine : PhysicsEngine
	{
		
		
			// 1. GİRDİLER (INPUTS)

			// Boşluğun manyetik geçirgenliği (μ₀) - T·m/A. Math.PI bir C# const
			// olduğu için bu ifade derleme zamanında sabitlenebiliyor.
			private const double VacuumPermeability = 4 * Math.PI * 1e-7;
			public InductanceMode Mode { get; set; } = InductanceMode.SelfInductance;

			// Birincil bobinin sarım sayısı (N1). Öz İndüktans modunda TEK bobinin
			// sarım sayısıdır (basitçe "N" gibi düşünülebilir).
			private double _turns1;
			public double Turns1
			{
				get => _turns1;
				set
				{
					if (value <= 0)
						throw new ArgumentOutOfRangeException(nameof(Turns1), "Sarım sayısı (N1) sıfırdan büyük olmalıdır.");
					_turns1 = value;
				}
			}

			// İkincil bobinin sarım sayısı (N2) - SADECE Karşılıklı İndüktans modunda kullanılır.
			private double _turns2;
			public double Turns2
			{
				get => _turns2;
				set
				{
					if (value <= 0)
						throw new ArgumentOutOfRangeException(nameof(Turns2), "Sarım sayısı (N2) sıfırdan büyük olmalıdır.");
					_turns2 = value;
				}
			}

			// Bobin(ler)in sarıldığı çekirdeğin kesit alanı (A) - m².
			private double _area;
			public double Area
			{
				get => _area;
				set
				{
					if (value <= 0)
						throw new ArgumentOutOfRangeException(nameof(Area), "Kesit alanı (A) sıfırdan büyük olmalıdır.");
					_area = value;
				}
			}

			// Bobinin/ortak çekirdeğin uzunluğu (l) - m.
			private double _length;
			public double Length
			{
				get => _length;
				set
				{
					if (value <= 0)
						throw new ArgumentOutOfRangeException(nameof(Length), "Uzunluk (l) sıfırdan büyük olmalıdır.");
					_length = value;
				}
			}

			// Akımın (birincil bobindeki) zamanla değişimi — indüklenen EMK için.
			public double InitialCurrent { get; set; }
			public double FinalCurrent { get; set; }

			private double _deltaTime;
			public double DeltaTime
			{
				get => _deltaTime;
				set
				{
					if (value <= 0)
						throw new ArgumentOutOfRangeException(nameof(DeltaTime), "Geçen süre (Δt) sıfırdan büyük olmalıdır.");
					_deltaTime = value;
				}
			}

			// 2. ÇIKTILAR (OUTPUTS)
			public double InductanceValue { get; private set; } // L (Öz) ya da M (Karşılıklı), Henry
			public double InducedEMF { get; private set; }       // Volt
			public double StoredEnergy { get; private set; }     // Joule — SADECE Öz İndüktans modunda anlamlı

			// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ
			// Akımın zamanla DOĞRUSAL değiştiği varsayımıyla I(t) eğrisi.
			public double[] ChartX_Time { get; private set; }
			public double[] ChartY_Current { get; private set; }

			// 4. HESAPLAMA MANTIĞI (CALCULATE)
			public override void Calculate()
			{
				SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI (İNDÜKTANS) ---\n\n";

				double currentChange = FinalCurrent - InitialCurrent;

				if (Mode == InductanceMode.SelfInductance)
				{
					// L = μ₀ * N² * A / l
					InductanceValue = VacuumPermeability * Math.Pow(Turns1, 2) * Area / Length;

					SolutionSteps += "1. Adım: Öz İndüktans (L) Hesabı\n";
					SolutionSteps += "   Kullanılan Formül: L = μ₀ * N² * A / l\n";
					SolutionSteps += $"   İşlem: {VacuumPermeability:E3} * {Turns1}² * {Area:F4} / {Length:F3} = {InductanceValue:E4} Henry\n\n";

					StoredEnergy = 0.5 * InductanceValue * Math.Pow(FinalCurrent, 2);
					SolutionSteps += "2. Adım: Bobinde Depolanan Enerji\n";
					SolutionSteps += "   Kullanılan Formül: U = 0.5 * L * I²\n";
					SolutionSteps += $"   İşlem: 0.5 * {InductanceValue:E3} * {FinalCurrent:F3}² = {StoredEnergy:E4} Joule\n\n";
				}
				else // MutualInductance
				{
					// M = μ₀ * N1 * N2 * A / l
					InductanceValue = VacuumPermeability * Turns1 * Turns2 * Area / Length;
					StoredEnergy = 0; // Basit U formülü mutual için burada verilmiyor

					SolutionSteps += "1. Adım: Karşılıklı İndüktans (M) Hesabı\n";
					SolutionSteps += "   Kullanılan Formül: M = μ₀ * N1 * N2 * A / l\n";
					SolutionSteps += $"   İşlem: {VacuumPermeability:E3} * {Turns1} * {Turns2} * {Area:F4} / {Length:F3} = {InductanceValue:E4} Henry\n\n";
				}

				// İndüklenen EMK: ε = -L(ya da M) * (ΔI / Δt)
				InducedEMF = -InductanceValue * (currentChange / DeltaTime);

				string emfLabel = Mode == InductanceMode.SelfInductance
					? "3. Adım: Öz-İndüklenen EMK (Kendi Devresinde)"
					: "2. Adım: İkincil Bobinde İndüklenen EMK";
				SolutionSteps += $"{emfLabel}\n";
				SolutionSteps += $"   Kullanılan Formül: ε = -{(Mode == InductanceMode.SelfInductance ? "L" : "M")} * (ΔI / Δt)\n";
				SolutionSteps += $"   İşlem: -{InductanceValue:E3} * (({FinalCurrent:F3} - {InitialCurrent:F3}) / {DeltaTime:F3}) = {InducedEMF:E4} Volt\n";

				SolutionSteps += "\n--------------------------------------------------\n";
				SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
				SolutionSteps += $"   {(Mode == InductanceMode.SelfInductance ? "Öz İndüktans (L)" : "Karşılıklı İndüktans (M)")} : {InductanceValue:E4} Henry\n";
				SolutionSteps += $"   İndüklenen EMK                        : {InducedEMF:E4} Volt\n";
				if (Mode == InductanceMode.SelfInductance)
					SolutionSteps += $"   Depolanan Enerji                       : {StoredEnergy:E4} Joule\n";

				// --- GRAFİK: I(t), başlangıçtan bitişe doğrusal değişim ---
				int pointCount = 100;
				ChartX_Time = new double[pointCount];
				ChartY_Current = new double[pointCount];

				double timeStep = DeltaTime / (pointCount - 1);
				for (int i = 0; i < pointCount; i++)
				{
					double t = i * timeStep;
					ChartX_Time[i] = t;
					ChartY_Current[i] = InitialCurrent + (currentChange * (t / DeltaTime));
				}
			}

			protected override string GetShortResultText()
			{
				return $" {(Mode == InductanceMode.SelfInductance ? "L" : "M")} = {InductanceValue:E4} Henry\n" +
					   $" İndüklenen EMK = {InducedEMF:E4} Volt\n";
			}

			public override void Reset()
			{
				SolutionSteps = string.Empty; // PhysicsEngine.Reset() abstract, base.Reset() cagrilamaz

				Mode = InductanceMode.SelfInductance;
				_turns1 = 0;
				_turns2 = 0;
				_area = 0;
				_length = 0;
				InitialCurrent = 0;
				FinalCurrent = 0;
				_deltaTime = 0;

				InductanceValue = 0;
				InducedEMF = 0;
				StoredEnergy = 0;

				ChartX_Time = null;
				ChartY_Current = null;
			}
		}
	
}
