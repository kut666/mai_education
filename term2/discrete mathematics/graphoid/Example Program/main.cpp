#include <cstdlib>
#include <iostream>
#include <fstream>

using namespace std;

int main(int argc, char *argv[])
{
    //Loading matrix
    ifstream in(argv[1]);
    int razmer=0,i,j;
    in >> razmer; 
    razmer--;   
    int matrix[razmer+1][razmer+1];      
    for(i=0;i<=razmer;i++) {
            for(j=0;j<=razmer;j++) {
                    in >> matrix[i][j];
            }   
    }
    in.close();
    //////// Algorithm    
    for(i=0;i<=razmer;i++) {
            for(j=0;j<=razmer;j++) {
                    if(matrix[i][j]!=0) matrix[i][j]=0;
                    else if(i!=j) matrix[i][j] = 1;
                    printf("%d ",matrix[i][j]);
            }
            printf("\n");
    }    
    //Saving new matrix
    fstream out;
    out.open(argv[1]);
    out.clear();
    char buffer [33];
    itoa(razmer+1,buffer,10); 
    out << buffer << "\n";    
    for(i=0; i<=razmer;i++) {
        for(j=0;j<=razmer;j++) { 
            out << matrix[i][j];
            if(j!=razmer) out << " ";
        }
        if(i!=razmer) out << "\n";
    }
    out.close();
}
