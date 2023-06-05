using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AWSApiPersonas.Models;
using Newtonsoft.Json;
using AWSApiPersonas.Repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSApiPersonas;

public class Functions
{
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public Functions()
    {
    }


    /// <summary>
    /// A Lambda function to respond to HTTP Get methods from API Gateway
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The API Gateway response.</returns>
    public APIGatewayProxyResponse Get
        (APIGatewayProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogInformation("Get Request\n");
        RepositoryPersonas repo = new RepositoryPersonas();
        List<Persona> personasList = repo.GetPersonas();
        //CONVERTIMOS A JSON LA COLECCION DE PERSONAS
        string jsonPersonas = JsonConvert.SerializeObject(personasList);
        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = jsonPersonas,
            Headers = new Dictionary<string, string> 
            { 
                { "Content-Type", "text/plain" } 
            }
        };
        return response;
    }
}