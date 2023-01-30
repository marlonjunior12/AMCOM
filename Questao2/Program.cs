using Newtonsoft.Json;
using Questao2;
using System.Net.Http.Headers;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int page = 1;
        int totalGols = 0;
        int team_1_2 = 1;

        Application resultados = new Application();

        while (true)
        {
            HttpClient client = new HttpClient();
            string endereco_api = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team{team_1_2}={team}&page={page}";

            var response = client.GetAsync(endereco_api).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultados = JsonConvert.DeserializeObject<Application>(response.Content.ReadAsStringAsync().Result);

                if(team_1_2 == 1)
                    totalGols += resultados.data.Sum(x => int.Parse(x.team1goals));
                else
                    totalGols += resultados.data.Sum(x => int.Parse(x.team2goals));
            }
            else
            {                
                totalGols = 0;
            }

            if (page != resultados.total_pages)
                page++;
            else
            {
                if (team_1_2 == 2)
                    break;
                else
                {
                    team_1_2 = 2;
                    page = 1;
                }
            }
        }

        return totalGols;
    }
}