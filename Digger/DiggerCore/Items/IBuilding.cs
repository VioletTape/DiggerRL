namespace DiggerCore.Items {
    public interface IBuilding {
        void Visit(Digger digger);
        void LeftOver();
    }
}
