using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace havi_kifizetesek_LIB
{
    public class Monthly_Payments
    {
        List<Monthly_Payment> payments = new();

        public Monthly_Payments(IEnumerable<string> fileLines)
        {
            foreach (string fileLine in fileLines)
            {
                string[] line = fileLine.Split(";");
                string name = line[0];
                int payment = int.Parse(line[1]);

                payments.Add(new Monthly_Payment(name, payment));
            }
        }

        // 2. feladat
        public int this[string name] => payments.First(x => x.Name == name).Payment;

        // 3. feladat
        public Dictionary<string, int> workersOrderedByTheirNamesWithTheirPayments() => payments.GroupBy(x => x.Name).OrderBy(x => x.Key).ToDictionary(x => x.Key, y => (int)(Math.Round(y.Sum(x => x.Payment) / 100.0) * 100));

        // 4. feladat
        public Dictionary<int, int> breakPaymentIntoDenominationsPerWorker(int payment)
        {
            int[] paymentUnits = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100 };
            Dictionary<int, int> neededPaymentUnits = paymentUnits.ToDictionary(unit => unit, unitCount => 0);

            payment = (int)(Math.Round(payment / 100.0) * 100);

            foreach (var paymentUnit in paymentUnits)
            {
                int count = payment / paymentUnit;
                neededPaymentUnits[paymentUnit] = count;
                payment -= count * paymentUnit;
            }
            return neededPaymentUnits;
        }

        // 5. feladat
        public Dictionary<int, int> GetTotalDenominationsForAllWorkers()
        {
            int[] paymentUnits = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100 };
            Dictionary<int, int> totalNeededPaymentUnits = paymentUnits.ToDictionary(unit => unit, unitCount => 0);

            var totalPaymentsPerWorker = payments.GroupBy(p => p.Name).ToDictionary(x => x.Key, x => (int)(Math.Round(x.Sum(x => x.Payment) / 100.0) * 100));

            foreach (var paymentPerWorker in totalPaymentsPerWorker)
            {
                int payment = paymentPerWorker.Value;

                var paymentBreakdown = breakPaymentIntoDenominationsPerWorker(payment);

                foreach (var PaymentUnit in paymentBreakdown)
                {
                    totalNeededPaymentUnits[PaymentUnit.Key] += PaymentUnit.Value;
                }
            }
            return totalNeededPaymentUnits;
        }

        // 6. feladat
        public void fileWrite(string filename)
        {
            StreamWriter fileWriter = new StreamWriter(filename);

            foreach (var worker in workersOrderedByTheirNamesWithTheirPayments())
            {
                string[] monograms = worker.Key.Split(" ");
                fileWriter.Write($"{monograms[0][0]} {monograms[1][0]};");
                fileWriter.Write($"{worker.Value}");
                fileWriter.WriteLine();
            }
            fileWriter.Close();
        }
    }
}