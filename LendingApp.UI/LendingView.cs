using LendingApp.LendingApplication.Contract;
using LendingApp.LendingDomain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LendingApp.UI
{
    public partial class LendingView : Form
    {
        private readonly ILogger _logger;
        private IServiceCollection _services;

        public LendingView(IServiceCollection services, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LendingView>();
            _services = services;

            InitializeComponent();
        }

        private void AddLoanBtn_Click(object sender, EventArgs e)
        {
            var loanAggregator = _services.BuildServiceProvider().GetService<ILoanAggregator>();

            //TODO
            //Input validation - if invalid present an error using strings from Resources file
            //Remove hardcoded values and read these from the UI textBoxes
            var loanToAdd = new Loan(1, 10m, new Asset(1, 100m), new Applicant(1, 900));
            loanAggregator.AddLoan(loanToAdd);
        }

        private void ProcessLoansBtn_Click(object sender, EventArgs e)
        {
            //TODO
            //If exception is caught, present error to UI using strings in Resources file

            var loanAggregator = _services.BuildServiceProvider().GetService<ILoanAggregator>();
            var loanProcessor = _services.BuildServiceProvider().GetService<ILoanProcessor>();
            
            var loans = loanAggregator.GetLoans(LoanState.Unknown);

            foreach(var loan in loans)
            {
                var state = loanProcessor.ProcessLoan(loan);

                if(state == LoanState.Unknown)
                {
                    _logger.LogWarning("Error processing loan " + loan.Identifier);
                    //TODO
                    //Present error to UI
                    continue;
                }

                //Note: Consider batching as a possible performance improvement
                loanAggregator.UpdateState(loan.Identifier, state);
            }        
        }

        //TODO
        //Create UI to display loan metrics and call ILoanProcessor to present metrics
    }
}
