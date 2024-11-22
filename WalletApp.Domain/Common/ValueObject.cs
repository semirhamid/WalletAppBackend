namespace WalletApp.Domain.Common
{
  public abstract class ValueObject
  {
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
        return false;

      var other = (ValueObject)obj;
      return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
      return GetEqualityComponents()
          .Aggregate(0, (hash, obj) => hash ^ (obj?.GetHashCode() ?? 0));
    }
  }
}
