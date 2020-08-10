# dotnet_interview_task

## Część I
Kod źródłowy przedstawia przykładową implemetację metody, która docelowo ma obsługiwać metody http typu GET, POST czy DELETE. Metoda zaimplementowana jest w abstrakcyjnej klasie *HttpRequestHandler*, która stanowi bazę do implementacji klasy właściwej, obsługującej zapytania. Poprzez wysyłanie zapytania na dane, zewnętrzne API, zwracany jest obiekt response (wysyłany z powrotem z tego API), który jest następnie parsowany i finalnie reprezentuje on wartość zwracaną przez metodę *Handle*.

Problemem, miejscami poza implementacją i "bad design'em", może być np. error handling, który obecnie nie jest przystosowany do obsługi wyjątków, jakie mogą być zwracane podczas działania przykładowej aplikacji wykorzystującej metodę. Co do implementacji oraz "bad design'u, poprawione (według mnie :)) błędy oraz kod znajduje się w repozytorium, w klasie o tej samej nazwie co kod źródłowy. 

Jeśli chodzi o rzeczy, które są interesujące to jest to z pewnością wszechstronność tej klasy. Oferuje ona możliwość obsługi w zasadzie wszystkich zapytań bez konieczności pisania/powielania wielkiej ilości kodu. Rzeczą, która przykuła mój wzrok jest asynchroniczność operacji http, a w zasadzie jej implementacja i uwzględnienie. Wcześniej w znakomitej większości miałem do czynienia z Node.js i moim zdaniem sposób zapisu async/await wydaje się bardzo intuicyjny i odzwierciedlający asynchroniczność zapytań (tutaj, w połączeniu z Task'ami niemal identyczna funkcjonalność).

