using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChellengeTwo.Repo
{
    public enum TypesOfClaims
    {
        Car =1,
        Home,
        Theft
    }
    public class ClaimContent
    {
        public int ClaimID { get; set; }
        public TypesOfClaims ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimContent() { }

        public ClaimContent(int claimID, TypesOfClaims claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident.Date;
            DateOfClaim = dateOfClaim.Date;
            IsValid = isValid;
        }

    }
}
