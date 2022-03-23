# LAbb-4-API
- Hämta alla personer i systemet
[get]   https://localhost:5001/api/Person


- Hämta alla intressen som är kopplade till en specifik person
[get]   https://localhost:5001/api/interest/getpersoninterest?id=1


- Hämta alla länkar som är kopplade till en specifik person
[get]   https://localhost:5001/api/Webb/getpersonweb?id=1


- Koppla en person till ett nytt intresse
[Post]  https://localhost:5001/api/interest 
    {
        "interestName": "",
        "interestDescription": "",
        "personId": 
    }    


- Lägga in nya länkar för en specifik person och ett specifikt intresse
[Post]  https://localhost:5001/api/webb
    {
        "webbSiteName": "",
        "webbadress": "",
        "interestsId": 
    }
