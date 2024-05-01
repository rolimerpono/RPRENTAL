using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Repository.Interface;
using Microsoft.AspNetCore;

namespace DataService.Implementation
{
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly IWorker _iWorker;

        public ResetPasswordService(IWorker iworker)
        {
            _iWorker = iworker;   
        }
        public void Create(ResetPassword objResetPassword)
        {
            try
            {              
                _iWorker.tbl_ResetPassword.Add(objResetPassword);
                _iWorker.tbl_ResetPassword.Save();

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public ResetPassword Get(ResetPassword objData)
        {           
            try
            {
                var objReset = _iWorker.tbl_ResetPassword.Get(fw => fw.Token == objData.Token && fw.OTP == objData.OTP && fw.Email == objData.Email);
               
                if (objReset != null)
                {
                    return objReset;
                }

                return null!;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
