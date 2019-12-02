'''
    Chartesian coordinate system with Euclidian distance
'''
from math import sqrt

class Location:

    ''' From array of strings
    '''
    def __init__(self, coordinates):
        try:
            self.__coordinates = []
            for c in coordinates:
                self.__coordinates.append( float(c) )
            self.__dim = len(self.__coordinates)
        except Exception as e :
            raise Exception("Coordinates format does not match!")


    ''' Euclidian distance
            rounded to 4 decimals
    '''
    def dist_to(self, b):
        ret = sqrt( sum( [ abs(self.__coordinates[i] - b.__coordinates[i])**2 for i in range(self.__dim) ] ) )
        ret = round(ret, 4)
        return ret
