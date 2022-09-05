namespace SortImage
{
    public delegate void EscritaEventHandler(object sender, EventArgs e);
    public delegate void PopularEventHandler(object sender, EventArgs e);

    public partial class Form1 : Form
    {
        const string BINARYINSERTIONSORT = "BinaryInsertionSort";
        const string BITONICSORT = "BitonicSort";
        const string BUBBLESORT = "BubbleSort";
        const string BUBBLESORT2 = "BubbleSort2";
        const string BUBBLESORT3 = "BubbleSort3";
        const string COCKTAILSHAKERSORT = "CocktailShakerSort";
        const string COMBSORT = "CombSort";
        const string COUNTINGSORT = "CountingSort";
        const string CYCLESORT = "CycleSort";
        const string FLASHSORT = "FlashSort";
        const string HEAPSORT = "HeapSort";
        const string INSERTSORT = "InsertSort";
        const string INSERTSORT2 = "InsertSort2";
        const string MERGESORT = "MergeSort";
        const string ODDEVENSORT = "OddEvenSort";
        const string PANCAKESORT = "PancakeSort";
        const string PIGEONHOLESORT = "PigeonHoleSort";
        const string QUICKSORTDUALPIVOT = "QuickSortDualPivot";
        const string QUICKSORTLL = "QuickSortLL";
        const string QUICKSORTLR = "QuickSortLR";
        const string QUICKSORTTERNARYLR = "QuickSortTernaryLR";
        const string RADIXSORTLSD = "RadixSortLSD";
        const string RADIXSORTMSD = "RadixSortMSD";
        const string SELECTIONSORT = "SelectionSort";
        const string SHELLSORT = "ShellSort";
        const string SLOWSORT = "SlowSort";

        private int[]? m_array;
        private ArrayItem[]? vetor;
        private ArrayItem[]? vetorimg;

        private Image img;
        private Bitmap bmp;
        private Graphics graph;
        private float ratio;

        private int cnt;
        private bool iniciou = false;

        public Form1()
        {
            InitializeComponent();
            ratio = 1;
            cnt = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add(BINARYINSERTIONSORT);
            this.comboBox1.Items.Add(BITONICSORT);
            this.comboBox1.Items.Add(BUBBLESORT);
            this.comboBox1.Items.Add(BUBBLESORT2);
            this.comboBox1.Items.Add(BUBBLESORT3);
            this.comboBox1.Items.Add(COCKTAILSHAKERSORT);
            this.comboBox1.Items.Add(COMBSORT);
            this.comboBox1.Items.Add(COUNTINGSORT);
            this.comboBox1.Items.Add(CYCLESORT);
            this.comboBox1.Items.Add(FLASHSORT);
            this.comboBox1.Items.Add(HEAPSORT);
            this.comboBox1.Items.Add(INSERTSORT);
            this.comboBox1.Items.Add(INSERTSORT2);
            this.comboBox1.Items.Add(MERGESORT);
            this.comboBox1.Items.Add(ODDEVENSORT);
            this.comboBox1.Items.Add(PANCAKESORT);
            this.comboBox1.Items.Add(PIGEONHOLESORT);
            this.comboBox1.Items.Add(QUICKSORTDUALPIVOT);
            this.comboBox1.Items.Add(QUICKSORTLL);
            this.comboBox1.Items.Add(QUICKSORTLR);
            this.comboBox1.Items.Add(QUICKSORTTERNARYLR);
            this.comboBox1.Items.Add(RADIXSORTLSD);
            this.comboBox1.Items.Add(RADIXSORTMSD);
            this.comboBox1.Items.Add(SELECTIONSORT);
            this.comboBox1.Items.Add(SHELLSORT);
            this.comboBox1.Items.Add(SLOWSORT);
            this.comboBox1.Sorted = true;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            //Resetar();

            comboBox1.SelectedIndex = 0;
        }

        public virtual void OnEscreveu(object sender, EventArgs e)
        {
            //ContaEscrita();
        }

        private void Resetar()
        {
            int nums = bmp.Width * bmp.Height;
            int i;
            int j;
            uint x;
            uint y;

            iniciou = false;

            m_array = Enumerable.Range(1, nums).ToArray();
            Random rnd = new();
            m_array = m_array.OrderBy(c => rnd.Next()).ToArray();

            vetor = new ArrayItem[m_array.Length];
            vetorimg = new ArrayItem[m_array.Length];
            vetor.Initialize();
            vetorimg.Initialize();
            x = 0;
            y = 0;
            for (i = 0; i < m_array.Length; i++)
            {
                EscritaEventHandler d1 = new(OnEscreveu);
                j = m_array[i] - 1;
                vetor[i] = new ArrayItem
                {
                    Indice = i
                };
                vetorimg[i] = new ArrayItem
                {
                    Indice = i
                };

                //Escreveu += new EscritaEventHandler(ContaEscrita)

                vetor[i].Escreveu += d1;
                vetor[i].Valor = j;
                vetorimg[i].C = bmp.GetPixel((int)x, (int)y);
                vetorimg[i].X = x;
                vetorimg[i].Y = y;
                x++;
                if (x >= bmp.Width)
                {
                    x = 0;
                    y++;
                }
            }
            x = 0;
            y = 0;
            for (i = 0; i < m_array.Length; i++)
            {
                j = vetor[i].Valor;
                bmp.SetPixel((int)x, (int)y, vetorimg[j].C);
                x++;
                if (x >= bmp.Width)
                {
                    x = 0;
                    y++;
                }
            }
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap orig = new(openFileDialog1.FileName);
                bmp = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }

                ratio = (float)bmp.Width / (float)bmp.Height;

                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Width = (int)(pictureBox1.Height * ratio);
                //button2.Enabled = true;
                orig.Dispose();
                Resetar();

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = (int)(pictureBox1.Height * ratio);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? x;
            x = comboBox1.SelectedItem.ToString();
            qsPivotSel1.Visible = false;
            if (x != null)
            {
                if (x.StartsWith("Quick"))
                {
                    qsPivotSel1.Visible = true;
                    qsPivotSel1.SelectedIndex = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string? x;
            Algoritmos algo;

            iniciou = true;

            x = comboBox1.SelectedItem.ToString();
            PopularEventHandler d1 = new PopularEventHandler(OnPopular);
            algo = new Algoritmos(vetor);
            //algo.SetVetor(vetor);
            algo.SetQuickSortPivot(qsPivotSel1.Text);
            algo.Populou += d1;

            button1.Enabled = false;
            button2.Enabled = false;

            //var watch = new System.Diagnostics.Stopwatch();

            this.UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;

            //watch.Start();

            Form1.ActiveForm.Text = x;
            switch (x)
            {
                case INSERTSORT:
                    algo.InsertSort();
                    break;

                case SELECTIONSORT:
                    algo.SelectionSort();
                    break;

                case INSERTSORT2:
                    algo.InsertSort2();
                    break;

                case BINARYINSERTIONSORT:
                    algo.BinaryInsertionSort();
                    break;

                case MERGESORT:
                    algo.MergeSort();
                    break;

                case BUBBLESORT:
                    algo.BubbleSort();
                    break;

                case BUBBLESORT2:
                    algo.BubbleSort2();
                    break;

                case BUBBLESORT3:
                    algo.BubbleSort3();
                    break;

                case COCKTAILSHAKERSORT:
                    algo.CocktailShakerSort();
                    break;

                case COMBSORT:
                    algo.CombSort();
                    break;

                case ODDEVENSORT:
                    algo.OddEvenSort();
                    break;

                case SHELLSORT:
                    algo.ShellSort();
                    break;

                case QUICKSORTLR:
                    algo.QuickSortLR();
                    break;

                case QUICKSORTLL:
                    algo.QuickSortLL();
                    break;

                case QUICKSORTTERNARYLR:
                    algo.QuickSortTernaryLR();
                    break;

                case QUICKSORTDUALPIVOT:
                    algo.QuickSortDualPivot();
                    break;

                case HEAPSORT:
                    algo.HeapSort();
                    break;

                case RADIXSORTMSD:
                    algo.RadixSortMSD();
                    break;

                case RADIXSORTLSD:
                    algo.RadixSortLSD();
                    break;

                case COUNTINGSORT:
                    algo.CountingSort();
                    break;

                case BITONICSORT:
                    algo.BitonicSort();
                    break;

                case SLOWSORT:
                    algo.SlowSort();
                    break;

                case CYCLESORT:
                    algo.CycleSort();
                    break;

                case PANCAKESORT:
                    algo.PancakeSort();
                    break;

                case FLASHSORT:
                    algo.FlashSort();
                    break;

                case PIGEONHOLESORT:
                    algo.pigeonholeSort();
                    break;

                default:
                    break;
            }
            //watch.Stop();

            this.Cursor = Cursors.Default;
            this.UseWaitCursor = false;

            button1.Enabled = true;
            button2.Enabled = true;

            Popular();
        }

        private void Popular()
        {
            int i;
            int x;
            int y;
            bool mudar = false;
            if (vetor != null)
            {
                x = 0;
                y = 0;
                for (i = 0; i < m_array.Length; i++)
                {
                    bmp.SetPixel((int)x, (int)y, vetorimg[vetor[i].Valor].C);
                    x++;
                    if (x >= bmp.Width)
                    {
                        x = 0;
                        y++;
                    }
                }
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
            }
            Application.DoEvents();
        }

        public virtual void OnPopular(object sender, EventArgs e)
        {
            textBox1.Text = ((Algoritmos)sender).atual.ToString();
            Popular();
        }
    }
}