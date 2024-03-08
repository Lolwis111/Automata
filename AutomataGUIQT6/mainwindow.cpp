#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) : QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    ui->drawArea->setMainWindow(this);

    connect(ui->btnApply, &QPushButton::released, this, &MainWindow::buttonApply);
    connect(ui->btnCancel, &QPushButton::released, this, &MainWindow::button2);
    connect(ui->btnDelete, &QPushButton::released, this, &MainWindow::button3);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::buttonApply()
{
    int x = rand() % 300;
    int y = rand() % 300;

    points.push_back(QPointF(x, y));
}

void MainWindow::button2()
{
    
}

void MainWindow::button3()
{
    
}