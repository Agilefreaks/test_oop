'''   Exposes get_shops which reads a csv line by line

''' 

import os

class ShopsCSV:
    ''' 
        Params:
            file_name is the path for csv file
            loc is the array of coordinates
    '''
    def __init__(self, file_name):
        self.__file_name = file_name 


    ''' 
        Expected format for line: Cofee_Shop_Name, X, Y, ...
            if format not respected then Format exception is triggered
        
        Can be changed outside and transmited to get_shops method
    '''
    def parse_line( line ):
        try:
            s = line.strip(' \t\n\r').split(",")
            name = s[0]
            coordinates = []
            for x in s[1:]:
                coordinates.append( float(x) )
            return (name, coordinates)
        except Exception as e:
            raise Exception("Format exception") 


    ''' 
        Iterates through the text file
        Params: 
            line_parser - interprets the line returning shop_name and an array of coordinates 
    '''    
    def get_shops(self, line_parser= parse_line):
        if os.path.exists( self.__file_name ):
            with open(self.__file_name) as f:
                for line in f:
                    yield line_parser( line ) 
        else:
            raise( Exception("CofeeShop file does not exist!") )

