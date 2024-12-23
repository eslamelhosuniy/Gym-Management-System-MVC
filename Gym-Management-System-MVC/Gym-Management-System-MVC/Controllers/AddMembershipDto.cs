using System;
using System.Threading;

public class AddMembershipDto
{
    public CancellationToken MembershipID { get; internal set; }
    public int MembershipId { get; internal set; }
    public DateTime ExpiryDate { get; internal set; }
}