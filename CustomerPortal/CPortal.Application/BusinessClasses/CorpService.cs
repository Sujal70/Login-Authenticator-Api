using AutoMapper;
using ConfigReader;
using ConfigReader.Entities;
using DataHelper.HelperClasses;
using LT.Application.BusinessInterfaces;
using LT.Application.Utilities;
using LT.Core.DBEntities;
using LT.Core.ModelEntities;
using LT.Core.SPEntities.SPResults;
using LT.Infrastructure.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Data;

namespace LT.Application.BusinessClasses
{
    /// <summary>
    /// all services methods related to CorpNo
    /// </summary>
    public class CorpService(IUnitOfWork unitOfWork, IMapper mapper) : ICorpService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// GetFolderNameByCorpNo
        /// </summary>
        /// <param name="corpModel"></param>
        /// <param name="message"></param>
        /// <returns>bool</returns>
        public bool GetFolderNameByCorpNo(SurveyCorporateModel corpModel, Message message)
        {
            message.Messages.AddLog("Entered in GetCorpFolderName in Authenticate Service");

            if (corpModel.Parent > 0)
            {
                BaseSpecification<MSSurveyCorporate> spec = new()
                {
                    Criteria = a => a.Corporate_No == corpModel.Parent
                };
                corpModel.Folder = (string)_unitOfWork.MSSurveyCorpRepo.GetSingleValue(spec, "folder", message);
                return true;
            }
            return false;
        }

        /// <summary>
        /// GetCorpSettings
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="corporateNo"></param>
        /// <param name="message"></param>
        /// <returns>CorpSettingsModel</returns>
        public ParentsEmailDetails GetParentsEmailDetails(Message message)
        {
            DataSet parentstudentdetailset = _unitOfWork.ParentEmailSPRepo.GetSPDataSet(new
            {
                @MainCorpNo = 122799,
                @email = "ym170172@gmail.com",
            }, false, message);
            DataTable dataTable = parentstudentdetailset.Tables[0];
            ParentsEmailDetails details = new ParentsEmailDetails();
            message.Messages.AddLog("Exited from CampaignTrickle in DeletecaseService");
            details.ParentDetails = parentstudentdetailset.Tables[0].ToList<ParentDetails>();
            details.StudentDetails = parentstudentdetailset.Tables[1].ToList<StudentDetails>();
            return details;
        }

        /// <summary>
        /// GetExpiryDateByCorpNo
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="message"></param>
        /// <returns>DateTime</returns>
        public SurveyCorporateModel GetExpiryDateByCorpNo(decimal parent, Message message)
        {
            message.Messages.AddLog("Entered in GetExpiryDateByCorpNo in Corp Service");
            BaseSpecification<MSSurveyCorporate> spec = new()
            {
                Criteria = a => a.Corporate_No == parent

            };
            return _mapper.Map<SurveyCorporateModel>(_unitOfWork.MSSurveyCorpRepo.GetUniqueRecordBySpec(spec, message));
        }


    }
}
