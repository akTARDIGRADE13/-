using System;
public class Program {

    //不完全コレスキー分解
    //正定値対称行列Aを、対角要素が1の下三角行列と対角行列の積に(LDL^T)分解する
    int IncompleteCholeskyDecomp (float[, ] A, float[, ] L, float[] d, int n) {
        if (n <= 0)
            return 0;

        d[0] = A[0, 0];
        L[0, 0] = 1.0f;

        for (int i = 1; i < n; ++i) {
            // i < k の場合
            for (int j = 0; j < i; ++j) {
                if (Math.Abs (A[i, j]) < 1.0e-10)
                    continue;

                float lld = A[i, j];
                for (int k = 0; k < j; ++k) {
                    lld -= L[i, k] * L[j, k] * d[k];
                }
                L[i, j] = (1.0f / d[j]) * lld;
            }

            // i == k の場合
            float ld = A[i, i];
            for (int k = 0; k < i; ++k) {
                ld -= L[i, k] * L[i, k] * d[k];
            }
            d[i] = ld;
            L[i, i] = 1.0f;
        }
        return 1;
    }

    public static void Main () {
        int n = 2; //行列の大きさ
        float[, ] A = new float[, ] { { 1, 3 }, { 3, 4 } }; //n*nの正定値対称行列
        float[, ] L = new float[n, n]; //n*nで対角要素が1の下三角行列
        float[] d = new float[n]; //n*nの対角行列の対角要素

        Program obj = new Program ();
        obj.IncompleteCholeskyDecomp (A, L, d, n); //インスタンス化

        //出力
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write (L[i, j]);
            }
            Console.WriteLine ();
        }
        for (int i = 0; i < n; i++) {
            Console.Write (d[i]);
        }
    }
}