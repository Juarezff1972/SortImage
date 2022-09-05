namespace SortImage
{
    internal class ArrayItem : IComparable
    {
        private int v;
        private int indice;
        private bool mudou;
        private Color color;
        private uint x;
        private uint y;

        public ArrayItem()
        {
            mudou = true;
        }

        public event EscritaEventHandler? Escreveu;

        public int Indice
        {
            get
            {
                return indice;
            }
            set
            {
                indice = value;
            }
        }

        public Color C
        {
            get { return color; }
            set { color = value; }
        }

        public uint X
        {
            get => x;
            set { x = value; }
        }

        public uint Y
        {
            get => y;
            set { y = value; }
        }

        public int Valor
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
                //OnEscreveu(new EventArgs());
                Mudou = true;
                Dispara(new EventArgs());
            }
        }

        public void Ativa()
        {
            Dispara(new EventArgs());
        }

        public void Dispara(EventArgs e)
        {
            Escreveu?.Invoke(this, e);
        }

        public bool Mudou
        {
            get
            {
                return mudou;
            }
            set
            {
                mudou = value;
            }
        }

        public int CompareTo(Object? v1)
        {
            int ret;
            ArrayItem? a = (ArrayItem?)v1;
            ret = 0;

            if (a != null)
            {
                if (a.Valor == v)
                {
                    ret = 0;
                }

                if (a.Valor < v)
                {
                    ret = 1;
                }

                if (a.Valor > v)
                {
                    ret = -1;
                }
            }

            return ret;
        }

        /*public virtual void OnEscreveu(EventArgs e)
        {
            Escreveu?.Invoke(this, e);
        }*/

        public override string ToString()
        {
            return v.ToString();
        }
    }
}
