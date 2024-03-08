#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <vector>
#include <QPointF>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

    const std::vector<QPointF>* getPoints() const { return &points; }

private:
    Ui::MainWindow *ui;
    std::vector<QPointF> points;

private slots:
    void buttonApply();
    void button2();
    void button3();
};

#endif // MAINWINDOW_H