# SI
Application that finds shortest way for points in *.dxf (CAD) files and writes it into G-Code.

## PL
Aplikacja s�u�y do tworzenia g-kodu ze specjalnie spreparowanych plik�w *.dxf pochodz�cych z program�w CAD.
W miejsca wskazane w pliku *.dxf specjaln� warstw� aplikacja ustawia pola kt�re b�d� np. silikonowane na detalu.
Aktualnie aplikacja wczytuje plik *.dxf �aduj�c z niego pola (linie proste) i oblicza najkr�tsz� scie�k�
jak� mo�na wykona� przechodz�c przez wszystkie punkty (oszcz�dzanie czasu na linii produkcyjnej).

1. Za�aduj plik test.dxf lub wygeneruj kilka punkt�w.
2. Wybierz algorytm liczenia.
3. Kliknij "Calculate".