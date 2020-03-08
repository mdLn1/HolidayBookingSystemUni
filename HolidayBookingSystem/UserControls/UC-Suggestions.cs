using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSDatabase;
using SolutionUtils;

namespace HolidayBookingSystem.UserControls
{
    public partial class UC_Suggestions : UserControl
    {
        private static UC_Suggestions _instance;
        private HolidayRequest currentRequest;

        public static UC_Suggestions Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UC_Suggestions();
                }
                return _instance;
            }
        }
        public UC_Suggestions()
        {
            InitializeComponent();
        }

        public void findSuggestions(HolidayRequest holidayRequest)
        {
            currentRequest = holidayRequest;
            this.Cursor = Cursors.WaitCursor;
            SuggestionsComponent suggestions = new SuggestionsComponent(currentRequest);
            label1.ForeColor = Color.Black;

            label1.Text = "Generating Suggestions. Please wait";
            List<DateRange> suggestionsFound = suggestions.getSuggestions();
            if (suggestionsFound.Count == 0)
            {
                label1.Text = "No suggestions found";
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.Text = "Please select one suggestion";
                foreach (var suggestion in suggestionsFound)
                {
                    string[] arr = new string[4];
                    arr[0] = suggestion.StartDate.ToShortDateString();
                    arr[1] = suggestion.EndDate.ToShortDateString();
                    ListViewItem item = new ListViewItem(arr);
                    suggestionsListView.Items.Add(item);
                }
            }
            this.Cursor = Cursors.Default;
        }
        public void clearSuggestions()
        {
            suggestionsListView.Items.Clear();
        }
        private void suggesstionConfirmedButton_Click(object sender, EventArgs e)
        {
            if (suggestionsListView.SelectedItems.Count > 0)
            {
                int selIndex = suggestionsListView.SelectedIndices[0];
                ListViewItem selectedItem = suggestionsListView.Items[selIndex];
                UC_OutstandingHolidays.Instance.ConfirmSuggestion(Convert.ToDateTime(selectedItem.SubItems[0].Text),
                    Convert.ToDateTime(selectedItem.SubItems[1].Text));
            }
            else
            {
                DesktopAppUtils.popDefaultErrorMessageBox("No suggestion selected");
            }
        }

    }
}
