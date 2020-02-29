using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolutionUtils;

namespace HolidayBookingSystem.CustomControls
{
    class CalendarDataVisualization : DataGridView
    {
        [Browsable(true)]
        [Category("Custom Behavior")]
        [Description("Data Grid for Employee Holidays Visualization")]
        private DataGridViewTextBoxColumn day1;
        private DataGridViewTextBoxColumn day2;
        private DataGridViewTextBoxColumn day3;
        private DataGridViewTextBoxColumn day4;
        private DataGridViewTextBoxColumn day5;
        private DataGridViewTextBoxColumn day6;
        private DataGridViewTextBoxColumn day7;
        private List<DateRange> dateRanges;
        private int selectedMonth;
        private int selectedYear;

        public CalendarDataVisualization()
        {
            dateRanges = new List<DateRange>();
            DataGridViewCellStyle calendarDataGridViewStyle = new DataGridViewCellStyle();
            this.day1 = new DataGridViewTextBoxColumn() { HeaderText = "Monday", Name = "day1", ReadOnly = true };
            this.day2 = new DataGridViewTextBoxColumn() { HeaderText = "Tuesday", Name = "day2", ReadOnly = true };
            this.day3 = new DataGridViewTextBoxColumn() { HeaderText = "Wednesday", Name = "day3", ReadOnly = true };
            this.day4 = new DataGridViewTextBoxColumn() { HeaderText = "Thursday", Name = "day4", ReadOnly = true };
            this.day5 = new DataGridViewTextBoxColumn() { HeaderText = "Friday", Name = "day5", ReadOnly = true };
            this.day6 = new DataGridViewTextBoxColumn() { HeaderText = "Saturday", Name = "day6", ReadOnly = true };
            this.day7 = new DataGridViewTextBoxColumn() { HeaderText = "Sunday", Name = "day7", ReadOnly = true };
            selectedMonth = DateTime.Today.Month;
            selectedYear = DateTime.Today.Year;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.Anchor = AnchorStyles.None;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            this.BackgroundColor = Color.White;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns.AddRange(new DataGridViewColumn[] {
            this.day1,
            this.day2,
            this.day3,
            this.day4,
            this.day5,
            this.day6,
            this.day7});
            this.GridColor = SystemColors.ButtonFace;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.ScrollBars = ScrollBars.None;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.MaximumSize = new Size(555, 400);
            this.MinimumSize = new Size(550, 250);
            calendarDataGridViewStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            calendarDataGridViewStyle.BackColor = SystemColors.Window;
            calendarDataGridViewStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            calendarDataGridViewStyle.ForeColor = SystemColors.ControlText;
            calendarDataGridViewStyle.SelectionBackColor = SystemColors.Window;
            calendarDataGridViewStyle.SelectionForeColor = SystemColors.ControlText;
            calendarDataGridViewStyle.WrapMode = DataGridViewTriState.False;
            this.DefaultCellStyle = calendarDataGridViewStyle;
            RefreshGrid();
        }

        public void AddDateRange(DateRange dateRange)
        {
            dateRanges.Add(dateRange);
            dateRanges.OrderBy(x => x.EndDate);

        }

        public void AddDateRange(DateTime startDate, DateTime endDate)
        {
            dateRanges.Add(new DateRange(startDate, endDate));
            dateRanges.OrderBy(x => x.EndDate);

        }

        public void AddDateRangesList(List<DateRange> dateRanges)
        {
            this.dateRanges.AddRange(dateRanges);
            dateRanges.OrderBy(x => x.EndDate);
        }

        public void ChangeSelection(int month, int year)
        {
            if (selectedMonth != month || selectedYear != year
                    && month < 13 && month > 0 && year >= DateTime.Now.Year && year < DateTime.Now.Year + 2)
            {
                selectedYear = year;
                selectedMonth = month;
                RefreshGrid();
            }
        }

        public void RefreshGrid()
        {
            this.Rows.Clear();
            string firstDay = new DateTime(selectedYear, selectedMonth, 1).DayOfWeek.ToString();
            int lastDay = DateTime.DaysInMonth(selectedYear, selectedMonth);
            object[] data = new object[7];
            int dayWeek = GeneralUtils.getDayValue(firstDay);
            int k = 1;
            int i;
            if (dayWeek != 0)
            {
                for (i = 0; i < 7; i++)
                {
                    if (i < dayWeek)
                    {
                        data[i] = "";
                    }
                    else
                    {
                        data[i] = k++;
                    }
                }
                this.Rows.Add(data);
            }
            while (k + 7 <= lastDay)
            {
                data = new object[] { k, k + 1, k + 2, k + 3, k + 4, k + 5, k + 6 };
                this.Rows.Add(data);
                k += 7;
            }
            if (k < lastDay)
            {
                data = new object[7];
                for (i = 0; i < 7; i++)
                {
                    if (k + i <= lastDay)
                    {
                        data[i] = k + i;
                    }
                    else
                    {
                        data[i] = "";
                    }
                }
                this.Rows.Add(data);
            }
            UpdateTableColors();
        }

        public void UpdateTableColors()
        {
            if (dateRanges.Count == 0)
            {
                return;
            }
            DateTime firstDayOfMonth = new DateTime(selectedYear, selectedMonth, 1);
            int lastDay = DateTime.DaysInMonth(selectedYear, selectedMonth);
            DateTime lastDateMonth = new DateTime(selectedYear, selectedMonth, lastDay);

            var currentDataRanges = dateRanges.Where(x => (firstDayOfMonth <= x.StartDate && lastDateMonth >= x.StartDate)
                    || (x.EndDate >= firstDayOfMonth && x.EndDate <= lastDateMonth)).ToList();
            if(currentDataRanges.Count == 0)
            {
                return;
            }
            int rows = this.RowCount;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    string cellValue = this.Rows[i].Cells[j].Value.ToString();
                    if (!String.IsNullOrEmpty(cellValue))
                    {
                        int val = int.Parse(cellValue) - 1;
                        DateTime currentDate = firstDayOfMonth.AddDays(int.Parse(cellValue) - 1);
                        if (dateRanges.Any(x => x.StartDate <= currentDate && x.EndDate >= currentDate))
                            this.Rows[i].Cells[j].Style.BackColor = Color.SandyBrown;
                    }
                }
            }
            this.Refresh();

        }

        public void ClearDateRanges()
        {
            dateRanges = new List<DateRange>();
            RefreshGrid();
        }



    }
}
