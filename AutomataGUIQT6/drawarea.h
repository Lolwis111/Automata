#ifndef DRAWAREA_H
#define DRAWAREA_H

#include <QWidget>
#include <QTimer>
#include <QPainter>
#include "mainwindow.h"

class DrawArea : public QWidget
{
    Q_OBJECT
    QPainter painter;
    QTimer timer;
    const MainWindow* mainWindow;
public:
    DrawArea(QWidget *parent = 0);
    virtual ~DrawArea() {};
    
    void setMainWindow(const MainWindow *mainWindow);

    void paintEvent(QPaintEvent *);
};
#endif // MAINWINDOW_H