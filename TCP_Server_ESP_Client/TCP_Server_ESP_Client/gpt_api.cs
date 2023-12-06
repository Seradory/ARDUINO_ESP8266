using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_ESP_Client
{
    internal class gpt_api
    {
        string apiKey = "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"; // API anahtarınızı buraya ekleyin.
        OpenAI_API.Chat.Conversation conversation;



        public gpt_api()
        {
            OpenAIAPI api = new OpenAIAPI(apiKey);
            conversation = api.Chat.CreateConversation();
        }

        public async Task<string> soru_sor_cevap_alAsync(string soru)
        {

            conversation.AppendUserInput(soru);
            string response = await conversation.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
