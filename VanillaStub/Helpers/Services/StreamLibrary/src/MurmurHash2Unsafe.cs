namespace VanillaStub.Helpers.Services.StreamLibrary.src
{
    public unsafe class MurmurHash2Unsafe
    {
        private const uint m = 0x5bd1e995;
        private const int r = 24;

        public uint Hash(byte* data, int length)
        {
            if (length == 0)
                return 0;
            uint h = 0xc58f1a7b ^ (uint) length;
            int remainingBytes = length & 3; // mod 4
            int numberOfLoops = length >> 2; // div 4
            uint* realData = (uint*) data;
            while (numberOfLoops != 0)
            {
                uint k = *realData;
                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;
                numberOfLoops--;
                realData++;
            }

            switch (remainingBytes)
            {
                case 3:
                    h ^= (ushort) *realData;
                    h ^= (uint) *((byte*) realData + 2) << 16;
                    h *= m;
                    break;

                case 2:
                    h ^= (ushort) *realData;
                    h *= m;
                    break;

                case 1:
                    h ^= *((byte*) realData);
                    h *= m;
                    break;
            }

            // Do a few final mixes of the hash to ensure the last few
            // bytes are well-incorporated.

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
        }
    }
}