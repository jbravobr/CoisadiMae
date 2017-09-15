using CoisadiMae.Models;
using Prism.Commands;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using CoisadiMae.ApplicationServices;
using System.Threading.Tasks;
using CoisadiMae.Util.UIFunctions;

namespace CoisadiMae.ViewModels
{
    [ImplementPropertyChanged]
    public class ChatPageViewModel : BindableBase
    {
        readonly IChatApplicationService _chatService;
        readonly IApplicationService<Conversation> _conversationService;
        readonly IDialogsFunction _dialogFunction;

        public string MessageText { get; set; }
        public Conversation AtualConversation { get; set; }
        public DelegateCommand SendMessageCmd { get; set; }
        public Action<Message> NewMessage { get; set; }


        public ChatPageViewModel(IChatApplicationService chatService,
                                 IApplicationService<Conversation> conversationService,
                                 IDialogsFunction dialogFunction)
        {
            _chatService = chatService;
            _conversationService = conversationService;
            _dialogFunction = dialogFunction;
            SendMessageCmd = new DelegateCommand(SendMessage);

            Welcome();
        }

        async Task Welcome()
        {
            if (AtualConversation != null)
                return;

            var ret = await _chatService.DoConversation("Ola");
            if (ret!=null)
                await SetBotForConversation(ret);
        }

        async Task SetBotForConversation(ConversationResponse message)
        {
            try
            {
                var text = string.Join (" ", message.output.text);
                
                AtualConversation = new Conversation()
                {
                    Bot = new Bot { Name = "Ana Maria", Id = 1 },
                    Messages = new System.Collections.ObjectModel.ObservableCollection<Message>()
                };
                AtualConversation.Messages.Add(new Message { Text = text, Date = DateTime.Now, Owner = Models.Enums.EnumOwner.Bot });
                await _conversationService.AddAsync(AtualConversation);
                AtualConversation = (await _conversationService.GetAllAsync()).Last();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task SetMonForConversation(string momName, int momAge)
        {
            AtualConversation.Mom = new Mom() { FirstName = momName, Age = momAge };

            await _conversationService.AddAsync(AtualConversation);
            AtualConversation = await _conversationService.GetAsync(AtualConversation.Id);
        }

        Action SendMessage
        {
            get
            {
                return new Action(async () =>
                {
                    ConversationResponse ret = null;

                    if (!string.IsNullOrEmpty((MessageText)))
                        ret = await _chatService.DoConversation(MessageText);

                    if (ret!=null)
                    {
                        if (AtualConversation.Messages == null || !AtualConversation.Messages.Any())
                        {
                           

                            AtualConversation.Messages = new System.Collections.ObjectModel.ObservableCollection<Message>
                            {
                                new Message() { Text = MessageText, Date = DateTime.Now, Owner = Models.Enums.EnumOwner.Mom },
                                new Message() { Text = string.Join(" ", ret.output.text), Date = DateTime.Now, Owner = Models.Enums.EnumOwner.Bot }
                            };

                            await _conversationService.AddAsync(AtualConversation);
                            AtualConversation = (await _conversationService.GetAllAsync()).Last();
                        }
                        else
                        {
                            AtualConversation.Messages.Add(new Message() { Text = MessageText, Date = DateTime.Now, Owner = Models.Enums.EnumOwner.Mom });
                            AtualConversation.Messages.Add(new Message() { Text = string.Join(" ", ret.output.text), Date = DateTime.Now, Owner = Models.Enums.EnumOwner.Bot });
                        }

                        MessageText = string.Empty;
                    }
                    else
                        _dialogFunction.ShowToast(Util.Enums.EnumToastType.Warning, "Erro ao enviar mensagem, por favor tente novamente");

                    NewMessage.Invoke(AtualConversation.Messages.Last());
                });
            }
        }
    }
}