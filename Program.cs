using Logit_Transport.Data.Models;
using Logit_Transport.DataProcessor.ImportDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Logit_Transport.Services;
using Logit_Transport.Data;

namespace Logit_Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LogitDbContext();
            context.Database.EnsureCreated();

            var participantService = new ParticipantService(context);

            string message = participantService.CreateParticipant();
            Console.WriteLine(message);

        }


       

    }
}
