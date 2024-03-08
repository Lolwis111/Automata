/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 6.4.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QFormLayout>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QListView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>
#include "drawarea.h"

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QAction *actionExport_as;
    QAction *actionImport_xML;
    QAction *actionExit;
    QAction *actionCenter_scroll;
    QAction *actionReorder;
    QAction *actionStart;
    QAction *actionAbou;
    QWidget *centralwidget;
    QGridLayout *gridLayout;
    QFormLayout *formLayout;
    QVBoxLayout *verticalLayout;
    QListView *listView;
    QLineEdit *txtLabel;
    QCheckBox *checkStartState;
    QCheckBox *checkEndState;
    QPushButton *btnApply;
    QPushButton *btnCancel;
    QPushButton *btnDelete;
    QScrollArea *scrollArea;
    DrawArea *drawArea;
    QMenuBar *menubar;
    QMenu *menuFile;
    QMenu *menuView;
    QMenu *menuSimulate;
    QMenu *menuHelp;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName("MainWindow");
        MainWindow->resize(888, 704);
        actionExport_as = new QAction(MainWindow);
        actionExport_as->setObjectName("actionExport_as");
        actionImport_xML = new QAction(MainWindow);
        actionImport_xML->setObjectName("actionImport_xML");
        actionExit = new QAction(MainWindow);
        actionExit->setObjectName("actionExit");
        actionCenter_scroll = new QAction(MainWindow);
        actionCenter_scroll->setObjectName("actionCenter_scroll");
        actionReorder = new QAction(MainWindow);
        actionReorder->setObjectName("actionReorder");
        actionStart = new QAction(MainWindow);
        actionStart->setObjectName("actionStart");
        actionAbou = new QAction(MainWindow);
        actionAbou->setObjectName("actionAbou");
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName("centralwidget");
        gridLayout = new QGridLayout(centralwidget);
        gridLayout->setObjectName("gridLayout");
        formLayout = new QFormLayout();
        formLayout->setObjectName("formLayout");
        verticalLayout = new QVBoxLayout();
        verticalLayout->setObjectName("verticalLayout");
        listView = new QListView(centralwidget);
        listView->setObjectName("listView");

        verticalLayout->addWidget(listView);

        txtLabel = new QLineEdit(centralwidget);
        txtLabel->setObjectName("txtLabel");

        verticalLayout->addWidget(txtLabel);

        checkStartState = new QCheckBox(centralwidget);
        checkStartState->setObjectName("checkStartState");

        verticalLayout->addWidget(checkStartState);

        checkEndState = new QCheckBox(centralwidget);
        checkEndState->setObjectName("checkEndState");

        verticalLayout->addWidget(checkEndState);

        btnApply = new QPushButton(centralwidget);
        btnApply->setObjectName("btnApply");

        verticalLayout->addWidget(btnApply);

        btnCancel = new QPushButton(centralwidget);
        btnCancel->setObjectName("btnCancel");

        verticalLayout->addWidget(btnCancel);

        btnDelete = new QPushButton(centralwidget);
        btnDelete->setObjectName("btnDelete");

        verticalLayout->addWidget(btnDelete);


        formLayout->setLayout(0, QFormLayout::LabelRole, verticalLayout);

        scrollArea = new QScrollArea(centralwidget);
        scrollArea->setObjectName("scrollArea");
        scrollArea->setWidgetResizable(true);
        drawArea = new DrawArea();
        drawArea->setObjectName("drawArea");
        drawArea->setGeometry(QRect(0, 0, 602, 636));
        scrollArea->setWidget(drawArea);

        formLayout->setWidget(0, QFormLayout::FieldRole, scrollArea);


        gridLayout->addLayout(formLayout, 0, 0, 1, 1);

        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName("menubar");
        menubar->setGeometry(QRect(0, 0, 888, 23));
        menuFile = new QMenu(menubar);
        menuFile->setObjectName("menuFile");
        menuView = new QMenu(menubar);
        menuView->setObjectName("menuView");
        menuSimulate = new QMenu(menubar);
        menuSimulate->setObjectName("menuSimulate");
        menuHelp = new QMenu(menubar);
        menuHelp->setObjectName("menuHelp");
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName("statusbar");
        MainWindow->setStatusBar(statusbar);

        menubar->addAction(menuFile->menuAction());
        menubar->addAction(menuView->menuAction());
        menubar->addAction(menuSimulate->menuAction());
        menubar->addAction(menuHelp->menuAction());
        menuFile->addAction(actionExport_as);
        menuFile->addAction(actionImport_xML);
        menuFile->addSeparator();
        menuFile->addAction(actionExit);
        menuView->addAction(actionCenter_scroll);
        menuView->addAction(actionReorder);
        menuSimulate->addAction(actionStart);
        menuHelp->addAction(actionAbou);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "MainWindow", nullptr));
        actionExport_as->setText(QCoreApplication::translate("MainWindow", "Export as...", nullptr));
        actionImport_xML->setText(QCoreApplication::translate("MainWindow", "Import XML", nullptr));
        actionExit->setText(QCoreApplication::translate("MainWindow", "Exit", nullptr));
        actionCenter_scroll->setText(QCoreApplication::translate("MainWindow", "Center scroll", nullptr));
        actionReorder->setText(QCoreApplication::translate("MainWindow", "Reorder", nullptr));
        actionStart->setText(QCoreApplication::translate("MainWindow", "Start", nullptr));
        actionAbou->setText(QCoreApplication::translate("MainWindow", "About", nullptr));
        checkStartState->setText(QCoreApplication::translate("MainWindow", "Startstate", nullptr));
        checkEndState->setText(QCoreApplication::translate("MainWindow", "Endstate", nullptr));
        btnApply->setText(QCoreApplication::translate("MainWindow", "Apply", nullptr));
        btnCancel->setText(QCoreApplication::translate("MainWindow", "Cancel", nullptr));
        btnDelete->setText(QCoreApplication::translate("MainWindow", "Delete", nullptr));
        menuFile->setTitle(QCoreApplication::translate("MainWindow", "File", nullptr));
        menuView->setTitle(QCoreApplication::translate("MainWindow", "View", nullptr));
        menuSimulate->setTitle(QCoreApplication::translate("MainWindow", "Simulate", nullptr));
        menuHelp->setTitle(QCoreApplication::translate("MainWindow", "Help", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
