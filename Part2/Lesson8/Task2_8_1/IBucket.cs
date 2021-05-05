
namespace Task2_8_1
{
    public interface IBucket
    {
        public void SetFirst();
        public bool MoveNext();
        public bool AddValue(int value);
        public void Sort();
        public int GetValue();
        public void SetSize(int size);
        public IBucket Clone();
        public void Clear();
    }
}
