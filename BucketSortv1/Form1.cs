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

            txtOrder.AppendText("\nBuckets:\n");
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

            //...
            int index = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                bool isEmpty = true;
                for (int j = 0; j < bucketSize; j++)
                {
                    if (buckets[i][j] != 0)
                    {
                        isEmpty = false;
                        break;
                    }
                }

                txtOrder.AppendText("\nOrdenando Bucket " + (i + 1) + " (" + (i * (100 / bucketCount) + 1) + " - " + ((i + 1) * (100 / bucketCount)) + "): ");
                for (int j = 0; j < bucketSize; j++)
                {
                    if (buckets[i][j] != 0)
                    {
                        txtOrder.AppendText(buckets[i][j] + (j < bucketSize - 1 && buckets[i][j + 1] != 0 ? ", " : ""));
                    }
                }
                txtOrder.AppendText(Environment.NewLine);

                for (int j = 0; j < bucketSize; j++)
                {
                    int minIndex = -1;
                    for (int k = 0; k < bucketSize; k++)
                    {
                        if (buckets[i][k] != 0)
                        {
                            if (minIndex == -1 || buckets[i][k] < buckets[i][minIndex])
                            {
                                minIndex = k;
                            }
                        }
                    }

                    if (minIndex != -1)
                    {
                        txtOrder.AppendText("\n Moviendo " + buckets[i][minIndex] + " del Bucket " + (i + 1) + " al arreglo.\n");
                        numbers[index++] = buckets[i][minIndex];
                        buckets[i][minIndex] = 0;
                    }
                }
            }

            txtOrder.AppendText("\nArreglo ordenado: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                txtOrder.AppendText(numbers[i] + (i < numbers.Length - 1 ? ", " : ""));

            
            }





        }

    }
}

