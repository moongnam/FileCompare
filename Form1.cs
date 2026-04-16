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

        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    UpdateFileLists();
                }
            }
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    UpdateFileLists();
                }
            }
        }

        private void btnCopyFromLeft_Click_1(object sender, EventArgs e)
        {
            ProcessCopy(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            ProcessCopy(lvwRightDir, txtRightDir.Text, txtLeftDir.Text);
        }

        private void ProcessCopy(ListView sourceLv, string sourcePath, string destPath)
        {
            if (sourceLv.SelectedItems.Count == 0)
            {
                MessageBox.Show("복사할 파일을 선택해주세요.");
                return;
            }

            if (!Directory.Exists(sourcePath) || !Directory.Exists(destPath))
            {
                MessageBox.Show("양쪽 폴더를 모두 선택해야 복사가 가능합니다.");
                return;
            }

            foreach (ListViewItem item in sourceLv.SelectedItems)
            {
                string fileName = item.Text;
                if (string.IsNullOrEmpty(fileName)) continue;

                string srcFull = Path.Combine(sourcePath, fileName);
                string destFull = Path.Combine(destPath, fileName);

                if (File.Exists(srcFull))
                {
                    CopyFileWithConfirmation(srcFull, destFull);
                }
            }

            UpdateFileLists();
            MessageBox.Show("작업이 완료되었습니다.");
        }

        // [수정] 정말 위험한 상황(옛날 파일로 새 파일 덮어쓰기)에서만 경고창 띄우기
        private void CopyFileWithConfirmation(string srcPath, string destPath)
        {
            try
            {
                if (File.Exists(destPath))
                {
                    FileInfo srcInfo = new FileInfo(srcPath);
                    FileInfo destInfo = new FileInfo(destPath);

                    // 원본이 대상보다 '오래된' 경우(회색 -> 빨간색)에만 경고
                    if (srcInfo.LastWriteTime < destInfo.LastWriteTime)
                    {
                        string msg = "!!! 주의: 덮어쓰려는 원본 파일이 대상 파일보다 오래되었습니다 !!!\n\n" +
                                     $"[원본(옛날)]: {srcInfo.LastWriteTime}\n" +
                                     $"[대상(최신)]: {destInfo.LastWriteTime}\n\n" +
                                     "정말로 최신 파일을 옛날 파일로 덮어쓰시겠습니까?";

                        var result = MessageBox.Show(msg, "덮어쓰기 주의", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No) return; // '아니오' 누르면 복사 안 함
                    }
                }

                // 그 외의 경우(새 파일로 업데이트, 동일 날짜 등)는 묻지 않고 바로 복사
                File.Copy(srcPath, destPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }

        private void UpdateFileLists()
        {
            lvwLeftDir.Items.Clear();
            lvwRightDir.Items.Clear();

            string leftPath = txtLeftDir.Text;
            string rightPath = txtRightDir.Text;

            bool hasLeft = Directory.Exists(leftPath);
            bool hasRight = Directory.Exists(rightPath);

            if (hasLeft && !hasRight) { SimplePopulate(leftPath, lvwLeftDir); return; }
            if (!hasLeft && hasRight) { SimplePopulate(rightPath, lvwRightDir); return; }
            if (!hasLeft && !hasRight) return;

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
                        AddToList(lvwLeftDir, fLeft, Color.Black);
                        AddToList(lvwRightDir, fRight, Color.Black);
                    }
                    else if (fLeft.LastWriteTime > fRight.LastWriteTime)
                    {
                        AddToList(lvwLeftDir, fLeft, Color.Red);   // New
                        AddToList(lvwRightDir, fRight, Color.Gray); // Old
                    }
                    else
                    {
                        AddToList(lvwLeftDir, fLeft, Color.Gray);  // Old
                        AddToList(lvwRightDir, fRight, Color.Red);  // New
                    }
                }
                else if (inLeft)
                {
                    AddToList(lvwLeftDir, leftFiles[fileName], Color.Purple); // 단독
                    lvwRightDir.Items.Add(new ListViewItem(""));
                }
                else if (inRight)
                {
                    lvwLeftDir.Items.Add(new ListViewItem(""));
                    AddToList(lvwRightDir, rightFiles[fileName], Color.Purple); // 단독
                }
            }
        }

        private void SimplePopulate(string path, ListView lv)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles()) { AddToList(lv, file, Color.Black); }
        }

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
        private void lvwLeftDir_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lvwRightDir_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}