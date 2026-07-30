using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{  /// <summary>
   /// Eğik atış (Projectile Motion) fiziği hesaplamalarını yapan somut motor sınıfı.
   /// MechanicsEngine sınıfından miras alır.
   /// </summary>
	public class ProjectileMotionEngine: MechanicsEngine
	{

		private double _angle;
		public double Angle
		{ get => _angle;
			set
			{
				if (value < 0 || value > 90)
				{ throw new ArgumentOutOfRangeException(nameof(Angle), "Fırlatma açısı 0 ile 90 derece arasında olmalıdır"); }
				_angle = value;
			}
		}
		// 2. ÇIKTILAR (OUTPUTS)
		// Kullanıcının hesaplama bittikten sonra ekranda göreceği salt okunur (readonly) sonuçlar.
		
		public double MaxHeight { get; private set; }
		public double Range { get; private set; }
		// EĞİTİM MODÜLÜ ÇIKTISI
		

		// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ 
		public double[] TrajectoryX { get; private set; }
		public double[] TrajectoryY { get; private set; }

		// 3. HESAPLAMA MANTIĞI (CALCULATE)
		/// <summary>
		/// Eğik atış formüllerini kullanarak havada kalma süresi, maksimum yükseklik ve menzili hesaplar.
		/// </summary>
		public override void Calculate()
		{
			double radian = DegreesToRadian(Angle);
			// Dikey hız bileşeni: V0 * sin(theta)
			double verticalVelocity = InitialVelocity * Math.Sin(radian);
			// Yatay hız bileşeni: V0 * cos(theta)
			double horizontalVelocity = InitialVelocity * Math.Cos(radian);

			// 1. Uçuş Süresi Hesabı
			TimeLimit= (2 * verticalVelocity) / Gravity;

			// 2. Maksimum Yükseklik Hesabı
			MaxHeight = Math.Pow(verticalVelocity, 2) / (2 * Gravity);

			// 3. Menzil Hesabı
			Range = (Math.Pow(InitialVelocity, 2) * Math.Sin(2 * radian)) / Gravity;
			// ADIM ADIM ÇÖZÜM RAPORUNUN HAZIRLANMASI
			SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI ---\n\n";

			SolutionSteps += "1. Adım: Dikey Hız (Vy) Bileşeninin Ayrıştırılması (Trigonometrik Dönüşüm)\n";
			SolutionSteps += $"   Kullanılan Formül: Vy = v0 * sin(θ)\n";
			SolutionSteps += $"   İşlem: {InitialVelocity} * sin({Angle}°) = {verticalVelocity:F2} m/s\n\n";

			SolutionSteps += "2. Adım: Uçuş Süresi (t) Hesabı (Kinematik Hareket Denklemi)\n";
			SolutionSteps += $"   Kullanılan Formül: t = (2 * Vy) / g\n";
			SolutionSteps += $"   İşlem: (2 * {verticalVelocity:F2}) / {Gravity} = {TimeLimit:F2} saniye\n\n";

			SolutionSteps += "3. Adım: Maksimum Yükseklik (Hmax) Hesabı (Zamansız Hız Denklemi / Enerji Korunumu)\n";
			SolutionSteps += $"   Kullanılan Formül: Hmax = Vy² / (2 * g)\n";
			SolutionSteps += $"   İşlem: {Math.Pow(verticalVelocity, 2):F2} / (2 * {Gravity}) = {MaxHeight:F2} metre\n\n";
			SolutionSteps += "4. Adım: Menzil (Xmax) Hesabı (Yatayda Sabit Hızlı Hareket)\n";
			SolutionSteps += $"   Kullanılan Formül: Xmax = (v0² * sin(2θ)) / g\n";
			SolutionSteps += $"   İşlem: {Math.Pow(InitialVelocity, 2):F2} * sin({2 * Angle}°) / {Gravity} = {Range:F2} metre\n";
			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Uçuş Süresi    : {TimeLimit:F2} saniye\n";
			SolutionSteps += $"   Maks Yükseklik : {MaxHeight:F2} metre\n";
			
			
			SolutionSteps += $"   Menzil (Xmax)  : {Range:F2} metre\n";
			// --- GRAFİK İÇİN X VE Y KOORDİNATLARININ ÜRETİLMESİ ---
			// Yörüngeyi 100 parçaya bölerek pürüzsüz bir çizgi elde ediyoruz
			int pointCount = 100;
			TrajectoryX = new double[pointCount];
			TrajectoryY = new double[pointCount];

			double timeStep = TimeLimit / (pointCount - 1);

			for (int i = 0; i < pointCount; i++)
			{
				double t = i * timeStep;

				// X(t) ve Y(t) formülleri
				TrajectoryX[i] = horizontalVelocity * t;
				TrajectoryY[i] = (verticalVelocity * t) - (0.5 * Gravity * Math.Pow(t, 2));

				// Yere çarptığında sıfırın altına düşmesini engelle
				if (TrajectoryY[i] < 0) TrajectoryY[i] = 0;
			}
		}
		protected override string GetShortResultText()
		{
			return $" Uçuş Süresi    : {TimeLimit:F2} saniye\n Maks Yükseklik : {MaxHeight:F2} metre\n  Menzil (Xmax)  : {Range:F2} metre\n";
		}
		public override void Reset()
		{
			// Ata sınıftaki değişkenleri sıfırla (InitialVelocity, Mass, TimeLimit, SolutionSteps)
			base.Reset();

			// Sadece bu sınıfa özel değerleri sıfırla
			Angle = 0;
			MaxHeight = 0;
			Range = 0;

			// Dizileri temizle
			TrajectoryX = null;
			TrajectoryY = null;
		}
	}
}

