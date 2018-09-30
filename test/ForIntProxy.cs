namespace testUnity {
    public class ForIntProxy {
        public ForInt forInt;

        public void doSearch (int x,int z,int r) {
            for (int i = -r; i <= r; i++) {
                for (int j = -r; j <= r; j++) {
                    if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
                        continue;
                    }
                    forInt.action (x,z);
                }
            }
        }
    }
}