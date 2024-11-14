using System;
using System.Security.Policy;
namespace BucketSortv1
{
    public partial class Form1 : Form
    {
        Random random;
        int[] numbers;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            numbers = new int[10];
        }

        private void btnBucketSort_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
            }

            txtOrder.Text = string.Join(", ", numbers);
            BucketSort();

        }

        public void BucketSort()
        {

            int bucketCount = 5;
            int bucketSize = 5;
            int[][] buckets = new int[bucketCount][];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new int[bucketSize];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int bucketIndex = (numbers[i] - 1) / (100 / bucketCount);
                for (int j = 0; j < bucketSize; j++)
                {
                    if (buckets[bucketIndex][j] == 0)
                    {
                        buckets[bucketIndex][j] = numbers[i];
                        break;
                    }
                }
            }

            txtOrder.AppendText("\nBuckets: ");
            for (int i = 0; i < bucketCount; i++)
            {
                txtOrder.AppendText("Bucket " + (i + 1) + " (" + (i * (100 / bucketCount) + 1) + " - " + ((i + 1) * (100 / bucketCount)) + "): ");
                for (int j = 0; j < bucketSize; j++)
                {
                    if (buckets[i][j] != 0)
                    {
                        txtOrder.AppendText(buckets[i][j] + (j < bucketSize - 1 && buckets[i][j + 1] != 0 ? ", " : ""));
                    }
                }
                txtOrder.AppendText(Environment.NewLine);
            }

            txtOrder.AppendText("\nSorting each bucket:\n");
            for (int i = 0; i < bucketCount; i++)
            {
                txtOrder.AppendText("\nBucket " + (i + 1) + " (ordenado): ");

                for (int j = 1; j < bucketSize; j++)
                {
                    int current = buckets[i][j];
                    if (current == 0) break; // Ignorar elementos vacíos (0s)
                    int k = j - 1;

                    // Insertion Sort dentro del bucket
                    while (k >= 0 && buckets[i][k] > current)
                    {
                        buckets[i][k + 1] = buckets[i][k];
                        txtOrder.AppendText(string.Join(", ", buckets[i]) + Environment.NewLine); // Imprimir estado actual
                        k--;
                    }
                    buckets[i][k + 1] = current;
                    txtOrder.AppendText(string.Join(", ", buckets[i]) + Environment.NewLine); // Imprimir estado después de insertar
                }
            }

            // Copiar elementos de los buckets de vuelta al arreglo principal
            int index = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                for (int j = 0; j < bucketSize; j++)
                {
                    if (buckets[i][j] != 0)
                    {
                        numbers[index++] = buckets[i][j];
                    }
                }
            }

            // Imprimir el arreglo final ordenado
            txtOrder.AppendText("\nFinal order: ");
            txtOrder.AppendText(string.Join(", ", numbers));


        }

    }
}

