using System;
public class Program
{
    //粒子をグリッド振り分けるプログラム
    void sort_gird(List<List<int>> grid_table, int[] index_tabele, List<Vector3> position, float x_begin, float x_end, float y_begin, float y_end, float z_begin, float z_end, float re, int n)
    {
        for (int i = 0; i < n; i++)
        {
            //粒子iの座標の取得
            float x = position[i].x;
            float y = position[i].y;
            float z = position[i].z;
            if (x < x_begin | x > x_end) Time.timeScale = 0;
            if (y < y_begin | y > y_end) Time.timeScale = 0;
            if (z < z_begin | z > z_end) Time.timeScale = 0;

            //indexの計算
            int x_i = (int)((x - x_begin) / re + 1);
            int y_i = (int)((y - y_begin) / re + 1);
            int z_i = (int)((z - z_begin) / re + 1);
            int index = x_i * y_i * z_i - 1;

            //それぞれのリストの値を更新
            grid_table[index].Add(i);
            index_tabele[i] = index;
        }
    }

    //近傍粒子が含まれている可能性があるグリッドのindexを返す関数
    List<int> search_grid(int i, int x, int y, int z)
    {
        List<int> ans = new List<int>();
        bool flag1 = true, flag2 = true, flag3 = true, flag4 = true, flag5 = true, flag6 = true;
        if (i % x == 0) flag1 = false;
        if ((i + 1) % x == 0) flag2 = false;
        if (i - x < 0) flag3 = false;
        if (i + x > x * y * z - 1) flag4 = false;
        if (i - x * y < 0) flag5 = false;
        if (i + x * y > x * y * z - 1) flag6 = false;
        ans.Add(i);
        if (flag1)
        {
            ans.Add(i - 1);
            if (flag3)
            {
                ans.Add(i - x);
                ans.Add(i - x - 1);
                if (flag5)
                {
                    ans.Add(i - x * y);
                    ans.Add(i - x * y - x);
                    ans.Add(i - x * y - 1);
                    ans.Add(i - x * y - x - 1);
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        ans.Add(i - x + 1);
                        ans.Add(i - x * y + 1);
                        ans.Add(i - x * y - x + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            ans.Add(i + x + 1);
                            ans.Add(i - x * y + x);
                            ans.Add(i - x * y + x - 1);
                            ans.Add(i - x * y + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                                ans.Add(i + x * y - x + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                        else
                        {
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                                ans.Add(i + x * y - x + 1);
                            }
                        }
                    }
                    else
                    {
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            ans.Add(i - x * y + x);
                            ans.Add(i - x * y + x - 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                            }
                        }
                        else
                        {
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                            }
                        }
                    }
                }
                else
                {
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        ans.Add(i - x + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            ans.Add(i + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                                ans.Add(i + x * y - x + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                        else
                        {
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                                ans.Add(i + x * y - x + 1);
                            }
                        }
                    }
                    else
                    {
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                            }
                        }
                        else
                        {
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x - 1);
                            }
                        }
                    }
                }
            }
            else
            {
                if (flag5)
                {
                    ans.Add(i - x * y);
                    ans.Add(i - x * y - 1);
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        ans.Add(i - x * y - 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            ans.Add(i + x + 1);
                            ans.Add(i - x * y + x);
                            ans.Add(i - x * y + x - 1);
                            ans.Add(i - x * y + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                    }
                    else
                    {
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                            }
                        }
                    }
                }
                else
                {
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            ans.Add(i + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                    }
                    else
                    {
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x - 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y - 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x - 1);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (flag3)
            {
                ans.Add(i - x);
                if (flag5)
                {
                    ans.Add(i - x * y);
                    ans.Add(i - x * y - x);
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        ans.Add(i - x + 1);
                        ans.Add(i - x * y + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x + 1);
                            ans.Add(i - x * y + x);
                            ans.Add(i - x * y + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                        else
                        {
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x + 1);
                            }
                        }
                    }
                }
                else
                {
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        ans.Add(i - x + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                        else
                        {
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y - x);
                                ans.Add(i + x * y - x + 1);
                            }
                        }
                    }
                }
            }
            else
            {
                if (flag5)
                {
                    ans.Add(i - x * y);
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        ans.Add(i - x * y + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x + 1);
                            ans.Add(i - x * y + x);
                            ans.Add(i - x * y + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                    }
                }
                else
                {
                    if (flag2)
                    {
                        ans.Add(i + 1);
                        if (flag4)
                        {
                            ans.Add(i + x);
                            ans.Add(i + x + 1);
                            if (flag6)
                            {
                                ans.Add(i + x * y);
                                ans.Add(i + x * y + 1);
                                ans.Add(i + x * y + x);
                                ans.Add(i + x * y + x + 1);
                            }
                        }
                    }
                }
            }
        }
        return ans;
    }
}