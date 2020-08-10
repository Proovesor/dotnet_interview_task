# dotnet_interview_task

## Część I
Kod źródłowy przedstawia przykładową implemetację metody, która docelowo ma obsługiwać metody http typu GET, POST czy DELETE. Metoda zaimplementowana jest w abstrakcyjnej klasie *HttpRequestHandler*, która stanowi bazę do implementacji klasy właściwej, obsługującej zapytania. Poprzez wysyłanie zapytania na dane, zewnętrzne API, zwracany jest obiekt response (wysyłany z powrotem z tego API), który jest następnie parsowany i finalnie reprezentuje on wartość zwracaną przez metodę *Handle*.

Problemem, miejscami poza implementacją i "bad design'em", może być np. error handling, który obecnie nie jest przystosowany do obsługi wyjątków, jakie mogą być zwracane podczas działania przykładowej aplikacji wykorzystującej metodę. Co do implementacji oraz "bad design'u, poprawione (według mnie :)) błędy oraz kod znajduje się w repozytorium, w klasie o tej samej nazwie co w kodzie źródłowym. 

Jeśli chodzi o rzeczy, które są interesujące to jest to z pewnością wszechstronność tej klasy. Oferuje ona możliwość obsługi w zasadzie wszystkich zapytań bez konieczności pisania/powielania wielkiej ilości kodu. Rzeczą, która przykuła moją uwagę jest asynchroniczność operacji http, a w zasadzie jej implementacja i obsługa. Wcześniej w znakomitej większości miałem do czynienia z Node.js i moim zdaniem sposób zapisu async/await wydaje się bardzo intuicyjny i odzwierciedlający asynchroniczność zapytań (tutaj, w połączeniu z Task'ami niemal identyczna funkcjonalność).

## Część II oraz III
Zdecydowałem się na udostępnienie całej aplikacji (demo + testy) jako odpowiedzi na zadanie drugie oraz trzecie. Demo wykorzystuje proste zewnętrzne API do przeprowadznia podstawowych operacji CRUD. Całość procesu jest "fake'owa" - żadna zawartość nie jest tworzona ani usuwana z serwera, toteż pominięto takie problemy jakie powielanie ID postów itd. Na porzeby wersji demonstracyjnej pominąłem również problemy wynikające z samej aplikacji konsolowej jak np. nieodpowiedni typ wprowadzanych danych oraz zdecydowałem się na pozostawienie tzw. "magic stringów" :p Zdecydowałem się również na parsowanie odpowiedzi do najprostszej formy - stringów (miało to na celu pokazanie tylko, że aplikacja działa). Funkcjonalność dema można przetestować odpalając aplikację konsolową :).

### Komentarz
Osobiście zadanie wydawało mi się ciekawe, bo poruszało kilka kwestii związanych z web developmentem jak i samym C#. Jako, że wcześniej nie miałem wiele styczności z samym .Net, a większość czasu (jeśli chodzi o web dev) spędziłem w Node.js - mogłem odnieść do tych zadań posiadaną więdze ogólną jak i spróbować przekonwertować ją na potrzeby .Net czy też nauczyć się wielu nowych rzeczy.
