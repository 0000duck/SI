# SI
Application that finds shortest way for points in *.dxf (CAD) files and writes it into G-Code.

## PL
Aplikacja służy do tworzenia g-kodu ze specjalnie spreparowanych plików *.dxf pochodzących z programów CAD.
W miejsca wskazane w pliku *.dxf specjalną warstwą aplikacja ustawia pola które będą np. silikonowane na detalu.
Aktualnie aplikacja wczytuje plik *.dxf ładując z niego pola (linie proste) i oblicza najkrótszą scieżkę
jaką można wykonać przechodząc przez wszystkie punkty (oszczędzanie czasu na linii produkcyjnej).

1. Załaduj plik test.dxf lub wygeneruj kilka punktów.
2. Wybierz algorytm liczenia.
3. Kliknij "Calculate".
