# SI
Application that finds shortest way for points in *.dxf (CAD) files and writes it into G-Code.

## PL
Aplikacja s³u¿y do tworzenia g-kodu ze specjalnie spreparowanych plików *.dxf pochodz¹cych z programów CAD.
W miejsca wskazane w pliku *.dxf specjaln¹ warstw¹ aplikacja ustawia pola które bêd¹ np. silikonowane na detalu.
Aktualnie aplikacja wczytuje plik *.dxf ³aduj¹c z niego pola (linie proste) i oblicza najkrótsz¹ scie¿kê
jak¹ mo¿na wykonaæ przechodz¹c przez wszystkie punkty (oszczêdzanie czasu na linii produkcyjnej).

1. Za³aduj plik test.dxf lub wygeneruj kilka punktów.
2. Wybierz algorytm liczenia.
3. Kliknij "Calculate".