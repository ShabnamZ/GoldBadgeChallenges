using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimRepository
{
    public class ClaimRepository
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();


        public Queue<Claim>GetListOfClaims()
        {
            return _queueOfClaims;
        }


        public void AddClaimToQueue(Claim claim)
        {
            _queueOfClaims.Enqueue(claim);
            IsClaimValid(claim);
        }

        public void IsClaimValid(Claim claim)
        {
            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else claim.IsValid = false;
        }

        public Claim ViewNextClaim()
        {
            Claim nextClaim = _queueOfClaims.Peek();
            return nextClaim;
        }
       
        public Claim TakeNextClaim()
        {
            Claim nextClaim = _queueOfClaims.Dequeue();
            return nextClaim;
        }

        
    }
}
