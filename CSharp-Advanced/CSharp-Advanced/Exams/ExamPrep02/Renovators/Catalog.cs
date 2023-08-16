using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private Dictionary<string, Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new Dictionary<string, Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators > 0)
            {
                if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                {
                    return "Invalid renovator's information.";
                }
                else if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }
                else
                {
                    renovators.Add(renovator.Name, renovator);
                    NeededRenovators--;
                    return $"Successfully added {renovator.Name} to the catalog.";
                }
            }
            else
            {
                return "Renovators are no more needed.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.ContainsKey(name))
            {
                renovators.Remove(name);
                NeededRenovators--;
                
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovatorsCount = 0;

            foreach (Renovator renovator in renovators.Values.Where(x => x.Type == type))
            {
                renovators.Remove(renovator.Name);
                removedRenovatorsCount++;
                NeededRenovators++;
            }

            return removedRenovatorsCount;
        }

        public Renovator HireRenovator(string name)
        {
            if (renovators.ContainsKey(name))
            {
                renovators[name].Hired = true;
                return renovators[name];
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payRenovators = new List<Renovator>();

            foreach (Renovator renovator in renovators.Values.Where(x => x.Days >= days))
            {
                payRenovators.Add(renovator);
            }

            return payRenovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (Renovator renovator in renovators.Values.Where(x => x.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
