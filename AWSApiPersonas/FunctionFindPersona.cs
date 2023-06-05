using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AWSApiPersonas.Models;
using AWSApiPersonas.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AWSApiPersonas
{
    public class FunctionFindPersona
    {
        public APIGatewayProxyResponse Find
            (APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogInformation("Get Find Request\n");
            RepositoryPersonas repo = new RepositoryPersonas();
            Persona persona = repo.FindPersona(1);
            //CONVERTIMOS A JSON LA COLECCION DE PERSONAS
            string jsonPersona = JsonConvert.SerializeObject(persona);
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = jsonPersona,
                Headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain" }
            }
            };
            return response;
        }
    }
}
