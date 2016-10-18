import os
import re


def getRegexPattern():
    return "Upgrade[0-9]*\\.sql"


def getAllUpgradeFilenames():
    regex = re.compile(getRegexPattern())
    filenames = os.listdir(os.getcwd())
    correctFilenames = []
    for filename in filenames:
        if regex.match(filename):
            correctFilenames.append(filename)
    correctFilenames.sort()
    return correctFilenames


def insertSQLToDB(filename):
    #do stuff
    return ""

def installUpgrades():
    fileNames = getAllUpgradeFilenames()
    for fileName in fileNames:
        insertSQLToDB(fileName)


installUpgrades()