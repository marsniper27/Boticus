using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Boticus
{
    class MyBot
    {
        DiscordClient discord;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });
            discord.UsingCommands(x =>
           {
               x.PrefixChar = '!';
               x.AllowMentionPrefix = true;
           });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Which system do you play?");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("TOKEN", TokenType.Bot);
            });
        }
        private void Log(Object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
