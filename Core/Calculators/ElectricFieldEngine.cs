using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	
	/// <summary>
	  /// Elektrik Alan (Electric Field) hesaplamalarını yapan somut motor sınıfı.
	  /// Tek bir kaynak yükün (Q) uzayda bir noktada oluşturduğu elektrik alanını
	  /// hesaplar. ElectricalEngine sınıfından miras alır.
	  /// </summary>
		public class ElectricFieldEngine : ElectricalEngine
		{
			// 1. GİRDİLER (INPUTS)

			// Kaynak yük (Q) - Coulomb (C) cinsinden. Alanı üreten yük.
			private double _sourceCharge;
			public double SourceCharge
			{
				get => _sourceCharge;
				set
				{
					if (!IsChargeNonZero(value))
					{
						throw new ArgumentOutOfRangeException(nameof(SourceCharge),
							"Kaynak yük (Q) sıfır olamaz.");
					}
					_sourceCharge = value;
				}
			}
			// Distance (r) -> ElectricalEngine'den miras alınıyor (>0 kontrolü orada)

			// 2. ÇIKTILAR (OUTPUTS)
			public double ElectricField { get; private set; }   // E, N/C

			// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ
			// Elektrik alanının mesafeyle (1/r²) nasıl azaldığını göstermek için.
			public double[] DistanceX { get; private set; }
			public double[] FieldY { get; private set; }

			// 4. HESAPLAMA MANTIĞI (CALCULATE)
			/// <summary>
			/// Coulomb Yasası'nı kullanarak elektrik alanını hesaplar.
			/// </summary>
			public override void Calculate()
			{
				// Elektrik Alan Hesabı: E = k * |Q| / r²
				ElectricField = CoulombConstant * Math.Abs(SourceCharge) / Math.Pow(Distance, 2);

				// Yönü belirt: yük pozitifse alan yükten dışa doğru, negatifse yüke doğru
				string direction = SourceCharge > 0
					? "Yükten dışa doğru (Q pozitif)"
					: "Yüke doğru (Q negatif)";

				// ADIM ADIM ÇÖZÜM RAPORUNUN HAZIRLANMASI
				SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI ---\n\n";

				SolutionSteps += "1. Adım: Elektrik Alan (E) Hesabı (Coulomb Yasası)\n";
				SolutionSteps += $"   Kullanılan Formül: E = k * |Q| / r²\n";
				SolutionSteps += $"   İşlem: {CoulombConstant:E2} * {Math.Abs(SourceCharge):E2} / {Distance:F2}² = {ElectricField:E4} N/C\n\n";

				SolutionSteps += "2. Adım: Alanın Yönü\n";
				SolutionSteps += $"   Sonuç: {direction}\n";

				SolutionSteps += "\n--------------------------------------------------\n";
				SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
				SolutionSteps += $"   Elektrik Alan (E) : {ElectricField:E4} N/C\n";
				SolutionSteps += $"   Yön               : {direction}\n";

				// --- GRAFİK İÇİN X VE Y KOORDİNATLARININ ÜRETİLMESİ ---
				// 0.1*r ile 3*r aralığında 100 noktalı 1/r² eğrisi
				int pointCount = 100;
				DistanceX = new double[pointCount];
				FieldY = new double[pointCount];

				double startR = Distance * 0.1;
				double endR = Distance * 3.0;
				double stepR = (endR - startR) / (pointCount - 1);

				for (int i = 0; i < pointCount; i++)
				{
					double r = startR + (i * stepR);
					DistanceX[i] = r;
					FieldY[i] = CoulombConstant * Math.Abs(SourceCharge) / Math.Pow(r, 2);
				}
			}


			protected override string GetShortResultText()
			{
				return $" Elektrik Alan (E) : {ElectricField:E4} N/C\n";
			}

			public override void Reset()
			{
				base.Reset();

				_sourceCharge = 0;
				ElectricField = 0;

				DistanceX = null;
				FieldY = null;
			}
		}
}

