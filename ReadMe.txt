
Project Dok�mantasyonu

1. Package Manager arac�l��� ile a�a��daki paketler y�klenir.
	1.1. Microsoft.EntityFrameworkCore.SqlServer
	1.2. Microsoft.EntityFrameworkCore.Tools
2. Infrastructure klas�r� olu�turulur.
	2.1. Context klas�r� olu�turulur.
		2.1.1. PorjectContext.cs file eklenir.
3. Model klas�r� alt�na "Page.cs" eklenir.
4. Page entitsi DbSet edilir.
5. Migration i�lmeleri yap�l�r.
6. Infrastructure klas�r� alt�na "Seeding" klas�r� a��l�r.
	6.1. SeedData.cs eklenir.
	6.2. Program.cs s�n�f�n� d�zenleyin.
7. Proje aya�� kald�r�l�r ve database kontrol edilir.
8. Areas klas�r� eklenir.
	8.1. Admin area eklenir.
	8.2. Admin area roting i�lemi ger�ekle�tirilir. (Not: Scaffolding ile gelen readme'deki routing Asp .Net Core 2.1 aittir. Asp .Net Core 3.1'de end point mant���na ge�ilmi�tir. L�tfen Startup.cs'si alt�ndaki "Configure" metodunu kontrol edin.)
	8.3. Global alandaki Views alt�nda bulunan "Shared"+"ViewImports"+"ViewStart" yap�lar�n� kopyalay�p. Admin area alt�ndaki Views i�erisine yap��t�rd�k. (Not: ViewImports.cshtml dosyas�na ihtiyac�m�z olan, yada porjede s�kl�kla kullanaca��m�z yollar� ekleyebiliriz. B�ylelikle model ekledi�imizde yolunu klasik .Net'teki gibi uzun uzunday� yazm�yoruz.)
	8.4. Page kontroller eklendi.
	8.5. Page CRUD operasyonlar� halledildi. (Delete operasyonu i�in script yaz�ld�)
	8.6. CK edit�r implemtation yap�ld�.
		8.6.1. Client side library �zerinden Ck editor y�klenir.
		8.6.2. ckeditor.js _Layout page eklenir.
		8.6.3. �htiya� duyulan yerlerde kullan�labilir.
	8.7. Dinamic sorting i�lemi
		8.7.1. Client side library'den jqueryui.js y�klenir.
		8.7.2. _Layout page jqueryui.js eklenir.
		8.7.3. Index sayfas�na script yaz�l�r. HTML elementleri uygun �ekilde yakalan�r. (Projenin di�er index sayfalar�nda, �rne�in category index vb. yerlerde kullanmak istersek, harici bir js file'sine yaz�p d��ar�ya alabiliriz. Sonra ihtiya� olan sayfalarda bu js file eklenir.)
		8.7.4. Page controller i�erisine ReOrder action'u yaz�l�r.
	8.8. Category model olu�turulur ve db'ye g�� ettirilir.
	8.9. Category controller a��l�r ve CRUD operasyonlar� y�r�t�l�r.






