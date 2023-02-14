using System.Collections.Generic;

namespace TrainerTraineeApp
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Organization organization = new Organization { Name = "Pratian" };

            Trainer trainer = new Trainer();
            trainer.Organization = organization;
            Training training = new Training();
            training.Trainer = trainer;
            System.Console.WriteLine($"Training Org Name: {training.GetTrainingOrganizationName()}");


            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);
            System.Console.WriteLine($"No. of Trainees: {training.GetNumberOfTrainees()}");


            Unit u1 = new Unit { Duration = 120 };
            Unit u2 = new Unit { Duration = 60 };
            Unit u3 = new Unit { Duration = 30 };
            Unit u4 = new Unit { Duration = 120 };
            Unit u5 = new Unit { Duration = 60 };
            Unit u6 = new Unit { Duration = 30 };

            Module m1 = new Module();
            m1.Units.Add(u1);
            m1.Units.Add(u2);
            m1.Units.Add(u3);

            Module m2 = new Module();
            m2.Units.Add(u4);
            m2.Units.Add(u5);
            m2.Units.Add(u6);

            Course course = new Course();
            course.Modules.Add(m1);
            course.Modules.Add(m2);
            training.Course = course;

            System.Console.WriteLine($"Training Duration: {training.GetTrainingDurationInHours()}");
        }
    }

    class Organization
    {
        public string Name { get; set; }
    }

    class Trainer
    {
        public Organization Organization { get; set; }

        //public Trainee[] Trainees = new Trainee[10];

        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();


    }

    class Trainee
    {
        public Trainer Trainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
    }

    class Training
    {
        public Trainer Trainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Course Course { get; set; }

        public string GetTrainingOrganizationName()
        {
            return Trainer.Organization.Name;
        }

        public int GetNumberOfTrainees()
        {
            return Trainees.Count;
        }

        public int GetTrainingDurationInHours()
        {
            int totalDuration = 0;
            // calculate the duration
            // for each moudle
            foreach (Module module in Course.Modules)
            {
                // for each moudel iterate unit
                foreach (Unit unit in module.Units)
                {
                    totalDuration += unit.Duration;
                }
            }

            return totalDuration;
        }
    }

    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();
    }

    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    class Topic
    {
        public string Name { get; set; }
    }
}
