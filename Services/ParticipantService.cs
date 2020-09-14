using Logit_Transport.Data;
using Logit_Transport.Data.Models;
using Logit_Transport.DataProcessor.ImportDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Logit_Transport.Services
{
    public class ParticipantService : IPraticipantService
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedParticipant = "Imported {0}";

        private LogitDbContext context;

        public ParticipantService(LogitDbContext context)
        {
            this.context = context;
        }

        public string CreateParticipant()
        {
            var sb = new StringBuilder();

            Console.Write("Enter your First and Last Name or Company name:");
            string name = Console.ReadLine();

            Console.Write("Phone:");
            string phone = Console.ReadLine();

            Console.Write("Town:");
            string town = Console.ReadLine();

            Console.Write("Street:");
            string street = Console.ReadLine();

            Console.Write("Street Number:");
            string streetNumber = Console.ReadLine();

            Console.Write("Block:");
            string block = Console.ReadLine();

            Console.Write("Entrance:");
            char? entrance = char.Parse(Console.ReadLine());

            Console.Write("Floor:");
            int? floor = int.Parse(Console.ReadLine());


            //1. Тук правя инстанция на адреса без да се интересувам дали са верни данните. По-късно ще го проверявам
            var currImportAddressDto = new ImportAddressDto
            {
                Town = town,
                Street = street,
                StreetNumber = streetNumber,
                Block = block,
                Entrance = entrance,
                Floor = floor
            };

            //2. Тук проверявам дали адреса отговаря на изискванията, ако не гърмя
            if (!IsValid(currImportAddressDto))
            {
                sb.AppendLine(ErrorMessage);
                return sb.ToString().TrimEnd();
            }

            //3. Щом адреса отговаря на изискванията, то тогава си правя оригиналния адрес за да мога да го запазя в базата
            var currAddress = new Address
            {
                Town = currImportAddressDto.Town,
                Street = currImportAddressDto.Street,
                StreetNumber = currImportAddressDto.StreetNumber,
                Block = currImportAddressDto.Block,
                Entrance = currImportAddressDto.Entrance,
                Floor = currImportAddressDto.Floor
            };

            //4. Тук си правя ImportParticipantDto без проверка на входните данни
            var currImportParticipantDto = new ImportParticipantDto
            {
                Name = name,
                Phone = phone,
                Address = currAddress
            };

            //5. Тук вече си правя проверката на Name и Phone на ParticipantDto. Ако не е валидно името или телефона гърмя
            if (!IsValid(currImportAddressDto))
            {
                sb.AppendLine(ErrorMessage);
                return sb.ToString().TrimEnd();
            }

            //6. Ако всичко е валидно, правя си от ImportParticipantDto, оригиналния клас Participant и го записвам в базата данни ---> Кой ми вкарва нови Address в базата

            var currParticipant = new Participant
            {
                Name = currImportParticipantDto.Name,
                Phone = currImportParticipantDto.Phone,
                Address = currImportParticipantDto.Address
            };

            context.Participants.Add(currParticipant);
            context.SaveChanges();

            sb.AppendLine(string.Format(SuccessfullyImportedParticipant, currParticipant.Name));
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}
