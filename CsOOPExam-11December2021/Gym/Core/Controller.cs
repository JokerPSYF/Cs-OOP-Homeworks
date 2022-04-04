using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == nameof(BoxingGym))
            {
                gyms.Add(new BoxingGym(gymName));
                return String.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gyms.Add(new WeightliftingGym(gymName));
                return String.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
        }

        public string AddEquipment(string equipmentType)
        {
            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    equipment.Add(new BoxingGloves());
                    return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);

                case nameof(Kettlebell):
                    equipment.Add(new Kettlebell());
                    return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmenT = this.equipment.FindByType(equipmentType);

            if (equipmenT == null)
                    throw new InvalidOperationException
                        (String.Format(ExceptionMessages.InexistentEquipment,equipmentType));

            this.equipment.Remove(equipmenT);

            IGym thisGym = gyms.FirstOrDefault(x => x.Name == gymName);

            thisGym.AddEquipment(equipmenT);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym thisGym = gyms.FirstOrDefault(x => x.Name == gymName);

            switch (athleteType)
            {
                case nameof(Boxer):
                    if (thisGym.GetType().Name == nameof(BoxingGym))
                    {
                        thisGym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
                        return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                    }
                    else
                    {
                        return String.Format(OutputMessages.InappropriateGym);
                    }
                
                case nameof(Weightlifter):
                    if (thisGym.GetType().Name == nameof(WeightliftingGym))
                    {
                        thisGym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
                        return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                    }
                    else
                    {
                        return String.Format(OutputMessages.InappropriateGym);
                    }

                default:
                    throw new InvalidOperationException
                        (String.Format(ExceptionMessages.InvalidAthleteType));
            }
        }

        public string TrainAthletes(string gymName)
        {
            IGym thisGym = gyms.FirstOrDefault(x => x.Name == gymName);

            thisGym.Exercise();

            return String.Format(OutputMessages.AthleteExercise, thisGym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym thisGym = gyms.FirstOrDefault(x => x.Name == gymName);

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, thisGym.EquipmentWeight);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGym gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}