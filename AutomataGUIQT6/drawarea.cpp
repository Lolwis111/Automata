#include "drawarea.h"
#include "mainwindow.h"

DrawArea::DrawArea(QWidget *parent) : QWidget(parent)
{
    connect(&timer,SIGNAL(timeout()),this, SLOT(update()));
    timer.start(200);
}


void DrawArea::paintEvent(QPaintEvent *)
{
    painter.begin(this);

    for(const auto& pt : *this->mainWindow->getPoints())
    {
        painter.drawEllipse(pt, 50, 50);
        // painter.drawEllipse(50, 50, 100, 100);
    }

    painter.end();
}

void DrawArea::setMainWindow(const MainWindow* mainWindow) 
{
    this->mainWindow = mainWindow;
}