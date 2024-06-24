﻿using OpenAI_API;
using System;
using System.Threading.Tasks;

namespace T3_DelCastillo_JoseMiguel.Services
{
    public class OpenAIService
    {
        private readonly OpenAIAPI _api;

        public OpenAIService(string apiKey)
        {
            _api = new OpenAIAPI(apiKey);
        }

        public async Task<string> GetSummaryByNameAsync(string nombre)
        {
            try
            {
                var request = new OpenAI_API.Completions.CompletionRequest
                {
                    Model = "gpt-3.5-turbo-instruct", 
                    Prompt = $"Proporciona un resumen corto para el libro titulado '{nombre}'",
                    MaxTokens = 150
                };

                var result = await _api.Completions.CreateCompletionAsync(request);
                if (result != null && result.Completions != null && result.Completions.Count > 0)
                {
                    var choices = result.Completions[0].Text.Trim();
                    return choices;
                }
                else
                {
                    return "Error al obtener el resumen del libro.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el resumen del libro: {ex.Message}");
                return ($"Error al obtener el resumen del libro: {ex.Message}");
            }
        }
    }
}



