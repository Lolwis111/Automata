#include "drawable.h"
#include <QPointF>

Drawable::Drawable()
{
    this->z = 0;
    this->selected = false;
}

QPointF Drawable::getCenter()
{
    return this->rectangle.center();
}