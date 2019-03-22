using Chat.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Chat.Hubs
{
   public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            User user = (User)Context.Items["x"];
            return base.OnConnectedAsync();
        }

         /// <summary>
        /// Método responsável por encaminhar as mensagens pelo hub
        /// </summary>
        /// <param name="channel">Este parâmetro será a ponte entre duas conexões</param>
        /// <param name="user">Quem está enviando a mensagem</param>
        /// <param name="message">A mensagem enviada</param>
        /// <returns></returns>
        public async Task SendMessage(ChatMessage chat)
        {
            await Clients.All.SendAsync(chat.destination.ToString(), chat.sender, chat.message);
        }
    }
}