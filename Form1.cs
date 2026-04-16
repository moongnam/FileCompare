using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 왼쪽 버튼 클릭
        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    UpdateFileLists(); // 목록 갱신 및 비교 호출
                }
            }
        }

        // 오른쪽 버튼 클릭
        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    UpdateFileLists(); // 목록 갱신 및 비교 호출
                }
            }
        }

        /// <summary>
        /// 파일 목록을 가져오고 비교해서 색상을 입히는 핵심 함수
        /// </summary>
        private void UpdateFileLists()
        {
            // 1. 일단 양쪽 리스트뷰 비우기
            lvwLeftDir.Items.Clear();
            lvwRightDir.Items.Clear();

            string leftPath = txtLeftDir.Text;
            string rightPath = txtRightDir.Text;

            // 2. 경로 존재 여부 체크
            bool hasLeft = Directory.Exists(leftPath);
            bool hasRight = Directory.Exists(rightPath);

            // 한쪽이라도 경로가 없으면 한쪽만이라도 뿌려주고 종료
            if (hasLeft && !hasRight) { SimplePopulate(leftPath, lvwLeftDir); return; }
            if (!hasLeft && hasRight) { SimplePopulate(rightPath, lvwRightDir); return; }
            if (!hasLeft && !hasRight) return;

            // 3. 양쪽 다 경로가 있으면 '비교 로직' 가동
            DirectoryInfo leftDir = new DirectoryInfo(leftPath);
            DirectoryInfo rightDir = new DirectoryInfo(rightPath);

            var leftFiles = leftDir.GetFiles().ToDictionary(f => f.Name);
            var rightFiles = rightDir.GetFiles().ToDictionary(f => f.Name);
            var allFileNames = leftFiles.Keys.Union(rightFiles.Keys).OrderBy(n => n);

            foreach (var fileName in allFileNames)
            {
                bool inLeft = leftFiles.ContainsKey(fileName);
                bool inRight = rightFiles.ContainsKey(fileName);

                if (inLeft && inRight)
                {
                    var fLeft = leftFiles[fileName];
                    var fRight = rightFiles[fileName];

                    if (fLeft.LastWriteTime == fRight.LastWriteTime)
                    {
                        AddToList(lvwLeftDir, fLeft, Color.Black); // 동일
                        AddToList(lvwRightDir, fRight, Color.Black);
                    }
                    else if (fLeft.LastWriteTime > fRight.LastWriteTime)
                    {
                        AddToList(lvwLeftDir, fLeft, Color.Red);   // 왼쪽이 최신(New)
                        AddToList(lvwRightDir, fRight, Color.Gray); // 오른쪽이 과거(Old)
                    }
                    else
                    {
                        AddToList(lvwLeftDir, fLeft, Color.Gray);  // 왼쪽이 과거
                        AddToList(lvwRightDir, fRight, Color.Red);  // 오른쪽이 최신
                    }
                }
                else if (inLeft)
                {
                    AddToList(lvwLeftDir, leftFiles[fileName], Color.Purple); // 왼쪽 단독
                    lvwRightDir.Items.Add(new ListViewItem("")); // 줄 맞춤
                }
                else if (inRight)
                {
                    lvwLeftDir.Items.Add(new ListViewItem("")); // 줄 맞춤
                    AddToList(lvwRightDir, rightFiles[fileName], Color.Purple); // 오른쪽 단독
                }
            }
        }

        // 한쪽 폴더만 있을 때 단순히 목록만 뿌려주는 함수
        private void SimplePopulate(string path, ListView lv)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles())
            {
                AddToList(lv, file, Color.Black);
            }
        }

        // 리스트뷰에 아이템을 실제로 넣는 함수 (중복 코드 방지)
        private void AddToList(ListView lv, FileInfo file, Color color)
        {
            ListViewItem item = new ListViewItem(file.Name);
            item.SubItems.Add($"{(file.Length / 1024):N0} KB");
            item.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
            item.ForeColor = color;
            lv.Items.Add(item);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e) { }
    }
}