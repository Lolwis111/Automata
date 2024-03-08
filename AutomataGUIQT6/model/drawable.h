#include <string>
#include <QRectF>
#include <QPointF>

class Drawable
{
public:
    Drawable();
    virtual void Draw() = 0;

    QPointF getCenter();

    int getZ() { return this->z; }
    void setZ(int z) { this->z = z; }

    int getID() { return this->id; }
    void setID(int id) { this->id = id; }

    std::string getLabel() { return this->label; }
    void setLabel(std::string label) { this->label = label; }

    bool getSelected() { return this->selected; }
    void setSelected(bool selected) { this->selected = selected; }

    bool equals(const Drawable& other) { return other.id == id; }

private:
    int z;
    int id;
    std::string label;
    bool selected;
    QRectF rectangle;
};