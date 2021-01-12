﻿using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace CinemaKeeper.Service.Modules
{
    public class LockModule : ModuleBase<SocketCommandContext>
    {
        [RequireContext(ContextType.Guild)]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        [RequireUserPermission(GuildPermission.Connect | GuildPermission.Speak)]
        [Command("lock")]
        public async Task Lock()
        {
            var voiceChannel = (Context.User as SocketGuildUser)!.VoiceChannel;

            await voiceChannel.ModifyAsync(vcp => vcp.UserLimit = voiceChannel.Users.Count);
            await Context.Message.DeleteAsync();
        }
    }
}